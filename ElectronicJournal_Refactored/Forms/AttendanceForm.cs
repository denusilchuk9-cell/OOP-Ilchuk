using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ElectronicJournal.Business;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public partial class AttendanceForm : Form
    {
        private AttendanceService _attendanceService;
        private StudentService _studentService;
        private SubjectService _subjectService;

        public AttendanceForm(AttendanceService aService, StudentService sService, SubjectService subService)
        {
            InitializeComponent();
            _attendanceService = aService;
            _studentService = sService;
            _subjectService = subService;
            this.cmbStudent.SelectedIndexChanged += cmbStudent_SelectedIndexChanged;
            this.cmbSubject.SelectedIndexChanged += cmbSubject_SelectedIndexChanged;
            this.btnPresent.Click += btnPresent_Click;
            this.btnAbsent.Click += btnAbsent_Click;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                FormHelper.LoadStudentsToComboBox(cmbStudent, _studentService);
                FormHelper.LoadSubjectsToComboBox(cmbSubject, _subjectService);
                dtpDate.Value = DateTime.Now;
                cmbReason.Items.Clear();
                cmbReason.Items.AddRange(new string[] { "Хвороба", "Сімейні обставини", "Інше" });
                cmbReason.SelectedIndex = 0;
                LoadAttendance();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void LoadAttendance()
        {
            try
            {
                if (cmbStudent.SelectedItem != null && cmbSubject.SelectedItem != null)
                {
                    var student = (Student)cmbStudent.SelectedItem;
                    var subject = (Subject)cmbSubject.SelectedItem;
                    var allAttendance = _attendanceService.GetAttendanceByStudent(student.Id);
                    var filtered = allAttendance.Where(a => a.SubjectId == subject.Id).ToList();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = filtered;
                    if (dataGridView1.Columns.Count > 0)
                    {
                        if (dataGridView1.Columns.Contains("Id"))
                        {
                            dataGridView1.Columns["Id"].HeaderText = "ID";
                            dataGridView1.Columns["Id"].Width = 50;
                        }
                        if (dataGridView1.Columns.Contains("Date"))
                        {
                            dataGridView1.Columns["Date"].HeaderText = "Дата";
                            dataGridView1.Columns["Date"].Width = 100;
                            dataGridView1.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                        }
                        if (dataGridView1.Columns.Contains("IsPresent"))
                        {
                            dataGridView1.Columns["IsPresent"].HeaderText = "Присутній";
                            dataGridView1.Columns["IsPresent"].Width = 80;
                        }
                        if (dataGridView1.Columns.Contains("AbsenceReason"))
                        {
                            dataGridView1.Columns["AbsenceReason"].HeaderText = "Причина відсутності";
                            dataGridView1.Columns["AbsenceReason"].Width = 200;
                        }
                        if (dataGridView1.Columns.Contains("StudentId"))
                            dataGridView1.Columns["StudentId"].Visible = false;
                        if (dataGridView1.Columns.Contains("SubjectId"))
                            dataGridView1.Columns["SubjectId"].Visible = false;
                    }
                    dataGridView1.ClearSelection();
                    UpdateStats();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження відвідування: {ex.Message}");
            }
        }

        private void UpdateStats()
        {
            try
            {
                if (cmbStudent.SelectedItem != null)
                {
                    var student = (Student)cmbStudent.SelectedItem;
                    float percentage = _attendanceService.GetAttendancePercentage(student.Id);
                    lblStats.Text = $"Загальна відвідуваність: {percentage:F1}%";
                }
            }
            catch
            {
                lblStats.Text = "Відвідуваність: помилка";
            }
        }

        private void btnPresent_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedItem == null || cmbSubject.SelectedItem == null)
                {
                    MessageBox.Show("Виберіть студента та предмет");
                    return;
                }
                var student = (Student)cmbStudent.SelectedItem;
                var subject = (Subject)cmbSubject.SelectedItem;
                var attendance = new Attendance(student.Id, subject.Id, dtpDate.Value);
                _attendanceService.AddAttendance(attendance);
                LoadAttendance();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnAbsent_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedItem == null || cmbSubject.SelectedItem == null)
                {
                    MessageBox.Show("Виберіть студента та предмет");
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbReason.Text))
                {
                    MessageBox.Show("Виберіть причину відсутності");
                    return;
                }
                var student = (Student)cmbStudent.SelectedItem;
                var subject = (Subject)cmbSubject.SelectedItem;
                _attendanceService.MarkAbsent(student.Id, subject.Id, dtpDate.Value, cmbReason.Text);
                LoadAttendance();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendance();
        }
    }
}
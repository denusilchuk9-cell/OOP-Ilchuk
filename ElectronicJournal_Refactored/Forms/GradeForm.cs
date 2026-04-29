using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ElectronicJournal.Business;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public partial class GradeForm : Form
    {
        private GradeService _gradeService;
        private StudentService _studentService;
        private SubjectService _subjectService;
        private Label lblAverage;

        public GradeForm(GradeService gService, StudentService sService, SubjectService subService)
        {
            InitializeComponent();
            _gradeService = gService;
            _studentService = sService;
            _subjectService = subService;
            this.cmbStudent.SelectedIndexChanged += cmbStudent_SelectedIndexChanged;
            this.cmbSubject.SelectedIndexChanged += cmbSubject_SelectedIndexChanged;
            this.btnAdd.Click += btnAdd_Click;
            this.btnDelete.Click += btnDelete_Click;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            LoadData();
            AddAverageLabel();
            StyleButtons();
            StyleForm();
        }

        private void LoadData()
        {
            try
            {
                LoadStudents();
                LoadSubjects();
                SetupGradeTypeCombo();
                ResetFormFields();
                LoadGradesIfDataExists();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void LoadStudents()
        {
            var students = _studentService.GetAllStudents();
            cmbStudent.DataSource = null;
            cmbStudent.DataSource = students;
            cmbStudent.DisplayMember = "GetFullName";
            cmbStudent.ValueMember = "Id";
        }

        private void LoadSubjects()
        {
            var subjects = _subjectService.GetAllSubjects();
            cmbSubject.DataSource = null;
            cmbSubject.DataSource = subjects;
            cmbSubject.DisplayMember = "Name";
            cmbSubject.ValueMember = "Id";
        }

        private void SetupGradeTypeCombo()
        {
            cmbGradeType.Items.Clear();
            cmbGradeType.Items.AddRange(new string[] { "Лекція", "Практична", "Модульна", "Іспит" });
            cmbGradeType.SelectedIndex = 0;
        }

        private void ResetFormFields()
        {
            dtpDate.Value = DateTime.Now;
            txtGrade.Text = "";
        }

        private void LoadGradesIfDataExists()
        {
            var students = _studentService.GetAllStudents();
            var subjects = _subjectService.GetAllSubjects();
            if (students.Count > 0 && subjects.Count > 0)
            {
                LoadGrades();
            }
        }

        private void LoadGrades()
        {
            try
            {
                if (cmbStudent.SelectedItem != null && cmbSubject.SelectedItem != null)
                {
                    var student = (Student)cmbStudent.SelectedItem;
                    var subject = (Subject)cmbSubject.SelectedItem;
                    var allGrades = _gradeService.GetGradesByStudent(student.Id);
                    var filtered = allGrades.Where(g => g.SubjectId == subject.Id).ToList();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = filtered;
                    if (dataGridView1.Columns.Count > 0)
                    {
                        if (dataGridView1.Columns.Contains("Id"))
                        {
                            dataGridView1.Columns["Id"].HeaderText = "ID";
                            dataGridView1.Columns["Id"].Width = 50;
                        }
                        if (dataGridView1.Columns.Contains("Value"))
                        {
                            dataGridView1.Columns["Value"].HeaderText = "Оцінка";
                            dataGridView1.Columns["Value"].Width = 80;
                        }
                        if (dataGridView1.Columns.Contains("Date"))
                        {
                            dataGridView1.Columns["Date"].HeaderText = "Дата";
                            dataGridView1.Columns["Date"].Width = 100;
                            dataGridView1.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                        }
                        if (dataGridView1.Columns.Contains("GradeType"))
                        {
                            dataGridView1.Columns["GradeType"].HeaderText = "Тип";
                            dataGridView1.Columns["GradeType"].Width = 120;
                        }
                        if (dataGridView1.Columns.Contains("StudentId"))
                            dataGridView1.Columns["StudentId"].Visible = false;
                        if (dataGridView1.Columns.Contains("SubjectId"))
                            dataGridView1.Columns["SubjectId"].Visible = false;
                    }
                    dataGridView1.ClearSelection();
                    UpdateAverage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження оцінок: {ex.Message}");
            }
        }

        private void UpdateAverage()
        {
            try
            {
                if (lblAverage == null) return;
                if (cmbStudent.SelectedItem != null && cmbSubject.SelectedItem != null)
                {
                    var student = (Student)cmbStudent.SelectedItem;
                    var subject = (Subject)cmbSubject.SelectedItem;
                    float avg = _gradeService.GetStudentAverage(student.Id, subject.Id);
                    string strategyName = _gradeService.GetStrategyName();
                    lblAverage.Text = $"Середній бал ({strategyName}): {avg:F2}";
                }
            }
            catch
            {
                if (lblAverage != null)
                    lblAverage.Text = "Середній бал: помилка";
            }
        }

        private void AddAverageLabel()
        {
            lblAverage = new Label
            {
                Text = "Середній бал: —",
                Location = new Point(120, 230),
                Size = new Size(300, 20),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 123, 255)
            };
            this.Controls.Add(lblAverage);
        }

        private void StyleButtons()
        {
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdd.Cursor = Cursors.Hand;
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDelete.Cursor = Cursors.Hand;
        }

        private void StyleForm()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudent.SelectedItem == null || cmbSubject.SelectedItem == null)
                {
                    MessageBox.Show("Виберіть студента та предмет");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtGrade.Text))
                {
                    MessageBox.Show("Введіть оцінку");
                    return;
                }
                if (!int.TryParse(txtGrade.Text, out int value))
                {
                    MessageBox.Show("Оцінка має бути цілим числом");
                    return;
                }
                if (value < 0 || value > 100)
                {
                    MessageBox.Show("Оцінка має бути від 0 до 100");
                    return;
                }
                var student = (Student)cmbStudent.SelectedItem;
                var subject = (Subject)cmbSubject.SelectedItem;
                var grade = new Grade(student.Id, subject.Id, value, dtpDate.Value)
                {
                    GradeType = cmbGradeType.Text
                };
                _gradeService.AddGrade(grade);
                LoadGrades();
                txtGrade.Text = "";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Немає оцінок для видалення.");
                    return;
                }
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Виберіть оцінку для видалення.");
                    return;
                }
                var grade = dataGridView1.CurrentRow.DataBoundItem as Grade;
                if (grade == null)
                {
                    MessageBox.Show("Не вдалося отримати дані оцінки.");
                    return;
                }
                var result = MessageBox.Show($"Видалити оцінку {grade.Value} від {grade.Date.ToShortDateString()}?", "Підтвердження", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _gradeService.DeleteGrade(grade.Id);
                    LoadGrades();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrades();
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrades();
        }
    }
}
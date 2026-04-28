using System;
using System.Windows.Forms;
using ElectronicJournal.Business;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public partial class SubjectForm : Form
    {
        private SubjectService _subjectService;
        private BindingSource _subjectBindingSource;

        public SubjectForm(SubjectService sService)
        {
            InitializeComponent();
            _subjectService = sService;

            _subjectBindingSource = new BindingSource();
            dataGridView1.DataSource = _subjectBindingSource;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadSubjects();
        }

        private void LoadSubjects()
        {
            try
            {
                var subjects = _subjectService.GetAllSubjects();
                _subjectBindingSource.DataSource = subjects;
                _subjectBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Введіть назву предмета");
                    return;
                }

                var subject = new Subject(txtName.Text)
                {
                    TeacherName = txtTeacher.Text,
                    Hours = (int)numHours.Value,
                    ControlForm = cmbControl.Text
                };

                _subjectService.AddSubject(subject);
                LoadSubjects();
                ClearFields();
                MessageBox.Show("Предмет додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtTeacher.Text = "";
            numHours.Value = 0;
            cmbControl.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Немає предметів для видалення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Виберіть предмет для видалення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var subject = dataGridView1.CurrentRow.DataBoundItem as Subject;
                if (subject == null)
                {
                    MessageBox.Show("Не вдалося отримати дані предмета.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show($"Видалити предмет {subject.Name}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _subjectService.DeleteSubject(subject.Id);
                    LoadSubjects();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}
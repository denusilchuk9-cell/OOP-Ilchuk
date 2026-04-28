using System;
using System.Drawing;
using System.Windows.Forms;
using ElectronicJournal.Business;
using ElectronicJournal.Models;

namespace ElectronicJournal.Forms
{
    public partial class StudentForm : Form
    {
        private StudentService _studentService;
        private GradeService _gradeService;
        private Label lblStrategyInfo;
        private Button btnSimpleStrategy;
        private Button btnWeightedStrategy;
        private BindingSource _studentBindingSource;

        public StudentForm(StudentService sService, GradeService gService)
        {
            InitializeComponent();
            _studentService = sService;
            _gradeService = gService;

            // Налаштування BindingSource
            _studentBindingSource = new BindingSource();
            dataGridView1.DataSource = _studentBindingSource;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadStudents();
            SetupDataGridViewColumns();
            AddStrategyControls();
        }

        private void AddStrategyControls()
        {
            lblStrategyInfo = new Label
            {
                Text = $"Поточна стратегія: {_gradeService.GetStrategyName()}",
                Location = new Point(120, 230),
                Size = new Size(250, 20),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 123, 255)
            };
            this.Controls.Add(lblStrategyInfo);

            btnSimpleStrategy = new Button
            {
                Text = "Проста стратегія",
                Location = new Point(350, 150),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            btnSimpleStrategy.Click += BtnSimpleStrategy_Click;
            this.Controls.Add(btnSimpleStrategy);

            btnWeightedStrategy = new Button
            {
                Text = "Зважена стратегія",
                Location = new Point(350, 190),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 }
            };
            btnWeightedStrategy.Click += BtnWeightedStrategy_Click;
            this.Controls.Add(btnWeightedStrategy);
        }

        private void BtnSimpleStrategy_Click(object sender, EventArgs e)
        {
            _gradeService.SetStrategy(new SimpleAverageStrategy());
            lblStrategyInfo.Text = $"Поточна стратегія: {_gradeService.GetStrategyName()}";
            MessageBox.Show("Встановлено просту стратегію розрахунку", "Strategy Pattern");
        }

        private void BtnWeightedStrategy_Click(object sender, EventArgs e)
        {
            _gradeService.SetStrategy(new WeightedAverageStrategy());
            lblStrategyInfo.Text = $"Поточна стратегія: {_gradeService.GetStrategyName()}";
            MessageBox.Show("Встановлено зважену стратегію розрахунку", "Strategy Pattern");
        }

        private void SetupDataGridViewColumns()
        {
            if (dataGridView1.Columns.Count == 0) return;

            dataGridView1.Columns["Id"].HeaderText = "№";
            dataGridView1.Columns["Id"].Width = 50;
            dataGridView1.Columns["FirstName"].HeaderText = "Ім'я";
            dataGridView1.Columns["FirstName"].Width = 100;
            dataGridView1.Columns["LastName"].HeaderText = "Прізвище";
            dataGridView1.Columns["LastName"].Width = 100;
            dataGridView1.Columns["MiddleName"].HeaderText = "По батькові";
            dataGridView1.Columns["MiddleName"].Width = 100;
            dataGridView1.Columns["RecordBookNumber"].HeaderText = "№ заліковки";
            dataGridView1.Columns["RecordBookNumber"].Width = 100;

            if (dataGridView1.Columns.Contains("Email"))
                dataGridView1.Columns["Email"].Visible = false;
            if (dataGridView1.Columns.Contains("Phone"))
                dataGridView1.Columns["Phone"].Visible = false;
        }

        private void LoadStudents()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                _studentBindingSource.DataSource = students;
                _studentBindingSource.ResetBindings(false); // Примусове оновлення
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
                var student = new Student(txtFirstName.Text, txtLastName.Text)
                {
                    MiddleName = txtMiddleName.Text,
                    RecordBookNumber = txtRecordBook.Text
                };

                _studentService.AddStudent(student);
                LoadStudents(); // Перезавантажуємо список
                ClearFields();
                MessageBox.Show("Студента додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtRecordBook.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Немає студентів для видалення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Виберіть студента для видалення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var student = dataGridView1.CurrentRow.DataBoundItem as Student;
                if (student == null)
                {
                    MessageBox.Show("Не вдалося отримати дані студента.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show($"Видалити студента {student.LastName} {student.FirstName}?",
                    "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _studentService.DeleteStudent(student.Id);
                    LoadStudents(); // Перезавантажуємо список
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні: {ex.Message}");
            }
        }
    }
}
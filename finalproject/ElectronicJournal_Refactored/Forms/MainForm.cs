using System;
using System.Drawing;
using System.Windows.Forms;
using ElectronicJournal.Data;
using ElectronicJournal.Business;

namespace ElectronicJournal.Forms
{
    public partial class MainForm : Form
    {
        private StudentService _studentService;
        private SubjectService _subjectService;
        private GradeService _gradeService;
        private AttendanceService _attendanceService;

        public MainForm()
        {
            InitializeComponent();

            var studentRepo = RepositoryFactory.CreateStudentRepository();
            var subjectRepo = RepositoryFactory.CreateSubjectRepository();
            var gradeRepo = RepositoryFactory.CreateGradeRepository();
            var attendanceRepo = RepositoryFactory.CreateAttendanceRepository();

            _studentService = new StudentService(studentRepo);
            _subjectService = new SubjectService(subjectRepo);
            _gradeService = new GradeService(gradeRepo, studentRepo, subjectRepo);
            _attendanceService = new AttendanceService(attendanceRepo, studentRepo, subjectRepo);

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Електронний журнал";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(500, 400);
            this.BackColor = Color.FromArgb(240, 242, 245);

            // ТЕСТОВА КНОПКА
            Button btnTest = new Button
            {
                Text = "ТЕСТ",
                Size = new Size(200, 60),
                Location = new Point(150, 50),
                BackColor = Color.FromArgb(255, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnTest.Click += BtnTest_Click;
            this.Controls.Add(btnTest);

            Button btnStudents = new Button
            {
                Text = "Студенти",
                Size = new Size(200, 60),
                Location = new Point(150, 120),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnStudents.Click += BtnStudents_Click;
            this.Controls.Add(btnStudents);

            Button btnSubjects = new Button
            {
                Text = "Предмети",
                Size = new Size(200, 60),
                Location = new Point(150, 190),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnSubjects.Click += BtnSubjects_Click;
            this.Controls.Add(btnSubjects);

            Button btnGrades = new Button
            {
                Text = "Оцінки",
                Size = new Size(200, 60),
                Location = new Point(150, 260),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnGrades.Click += BtnGrades_Click;
            this.Controls.Add(btnGrades);

            Button btnAttendance = new Button
            {
                Text = "Відвідування",
                Size = new Size(200, 60),
                Location = new Point(150, 330),
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnAttendance.Click += BtnAttendance_Click;
            this.Controls.Add(btnAttendance);
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            testForm.ShowDialog();
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm(_studentService, _gradeService);
            studentForm.ShowDialog();
        }

        private void BtnSubjects_Click(object sender, EventArgs e)
        {
            SubjectForm subjectForm = new SubjectForm(_subjectService);
            subjectForm.ShowDialog();
        }

        private void BtnGrades_Click(object sender, EventArgs e)
        {
            GradeForm gradeForm = new GradeForm(_gradeService, _studentService, _subjectService);
            gradeForm.ShowDialog();
        }

        private void BtnAttendance_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm(_attendanceService, _studentService, _subjectService);
            attendanceForm.ShowDialog();
        }
    }
}
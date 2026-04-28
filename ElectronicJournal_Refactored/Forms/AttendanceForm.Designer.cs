namespace ElectronicJournal.Forms
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Button btnPresent;
        private System.Windows.Forms.Button btnAbsent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblReason;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.btnPresent = new System.Windows.Forms.Button();
            this.btnAbsent = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.Location = new System.Drawing.Point(160, 37);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(250, 24);
            this.cmbStudent.TabIndex = 0;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.cmbStudent_SelectedIndexChanged);

            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.Location = new System.Drawing.Point(160, 74);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(250, 24);
            this.cmbSubject.TabIndex = 1;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);

            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(160, 111);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 2;

            this.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReason.Items.AddRange(new object[] { "Хвороба", "Сімейні обставини", "Інше" });
            this.cmbReason.Location = new System.Drawing.Point(160, 148);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(150, 24);
            this.cmbReason.TabIndex = 3;

            this.btnPresent.Location = new System.Drawing.Point(160, 197);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Size = new System.Drawing.Size(100, 30);
            this.btnPresent.TabIndex = 4;
            this.btnPresent.Text = "Присутній";
            this.btnPresent.UseVisualStyleBackColor = true;
            this.btnPresent.Click += new System.EventHandler(this.btnPresent_Click);

            this.btnAbsent.Location = new System.Drawing.Point(270, 197);
            this.btnAbsent.Name = "btnAbsent";
            this.btnAbsent.Size = new System.Drawing.Size(100, 30);
            this.btnAbsent.TabIndex = 5;
            this.btnAbsent.Text = "Відсутній";
            this.btnAbsent.UseVisualStyleBackColor = true;
            this.btnAbsent.Click += new System.EventHandler(this.btnAbsent_Click);

            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(27, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 250);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.AllowUserToAddRows = false;

            this.lblStats.Location = new System.Drawing.Point(160, 230);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(300, 20);
            this.lblStats.Text = "Відвідуваність: 0%";

            this.lblStudent.Location = new System.Drawing.Point(40, 39);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(100, 20);
            this.lblStudent.Text = "Студент:";

            this.lblSubject.Location = new System.Drawing.Point(40, 76);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(100, 20);
            this.lblSubject.Text = "Предмет:";

            this.lblDate.Location = new System.Drawing.Point(40, 113);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 20);
            this.lblDate.Text = "Дата:";

            this.lblReason.Location = new System.Drawing.Point(40, 150);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(100, 20);
            this.lblReason.Text = "Причина:";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 530);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnAbsent);
            this.Controls.Add(this.btnPresent);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblStudent);
            this.Name = "AttendanceForm";
            this.Text = "Відвідування";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
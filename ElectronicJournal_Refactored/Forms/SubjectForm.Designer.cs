namespace ElectronicJournal.Forms
{
    partial class SubjectForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTeacher;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.ComboBox cmbControl;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblControl;

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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTeacher = new System.Windows.Forms.TextBox();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.cmbControl = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblControl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.txtName.Location = new System.Drawing.Point(160, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 0;

            this.txtTeacher.Location = new System.Drawing.Point(160, 74);
            this.txtTeacher.Name = "txtTeacher";
            this.txtTeacher.Size = new System.Drawing.Size(200, 22);
            this.txtTeacher.TabIndex = 1;

            this.numHours.Location = new System.Drawing.Point(160, 111);
            this.numHours.Maximum = 500;
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(120, 22);
            this.numHours.TabIndex = 2;

            this.cmbControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbControl.Items.AddRange(new object[] { "Залік", "Іспит" });
            this.cmbControl.Location = new System.Drawing.Point(160, 148);
            this.cmbControl.Name = "cmbControl";
            this.cmbControl.Size = new System.Drawing.Size(150, 24);
            this.cmbControl.TabIndex = 3;

            this.btnAdd.Location = new System.Drawing.Point(160, 197);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(270, 197);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(27, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 250);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.AllowUserToAddRows = false;

            this.lblName.Location = new System.Drawing.Point(40, 39);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 20);
            this.lblName.Text = "Назва:";

            this.lblTeacher.Location = new System.Drawing.Point(40, 76);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(100, 20);
            this.lblTeacher.Text = "Викладач:";

            this.lblHours.Location = new System.Drawing.Point(40, 113);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(100, 20);
            this.lblHours.Text = "Годин:";

            this.lblControl.Location = new System.Drawing.Point(40, 150);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(100, 20);
            this.lblControl.Text = "Форма контролю:";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 531);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbControl);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.txtTeacher);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblControl);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblTeacher);
            this.Controls.Add(this.lblName);
            this.Name = "SubjectForm";
            this.Text = "Предмети";

            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
namespace VBTracker.GUI
{
    partial class AttendanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cboSchedules = new System.Windows.Forms.ComboBox();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.cboClasses = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.pnlAttendanceInput = new System.Windows.Forms.Panel();
            this.btnSaveAttendance = new System.Windows.Forms.Button();
            this.dgvAttendanceInput = new System.Windows.Forms.DataGridView();
            this.lblAttendanceInputTitle = new System.Windows.Forms.Label();
            this.pnlAttendanceView = new System.Windows.Forms.Panel();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.lblAttendanceViewTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlAttendanceInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceInput)).BeginInit();
            this.pnlAttendanceView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ ĐIỂM DANH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.cboSchedules);
            this.pnlFilter.Controls.Add(this.lblSchedule);
            this.pnlFilter.Controls.Add(this.cboClasses);
            this.pnlFilter.Controls.Add(this.lblClass);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 60);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(800, 50);
            this.pnlFilter.TabIndex = 1;
            // 
            // cboSchedules
            // 
            this.cboSchedules.FormattingEnabled = true;
            this.cboSchedules.Location = new System.Drawing.Point(540, 14);
            this.cboSchedules.Name = "cboSchedules";
            this.cboSchedules.Size = new System.Drawing.Size(200, 21);
            this.cboSchedules.TabIndex = 3;
            this.cboSchedules.SelectedIndexChanged += new System.EventHandler(this.cboSchedules_SelectedIndexChanged);
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(480, 17);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(54, 13);
            this.lblSchedule.TabIndex = 2;
            this.lblSchedule.Text = "Lịch học:";
            // 
            // cboClasses
            // 
            this.cboClasses.FormattingEnabled = true;
            this.cboClasses.Location = new System.Drawing.Point(73, 14);
            this.cboClasses.Name = "cboClasses";
            this.cboClasses.Size = new System.Drawing.Size(200, 21);
            this.cboClasses.TabIndex = 1;
            this.cboClasses.SelectedIndexChanged += new System.EventHandler(this.cboClasses_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(12, 17);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(55, 13);
            this.lblClass.TabIndex = 0;
            this.lblClass.Text = "Lớp học:";
            // 
            // pnlAttendanceInput
            // 
            this.pnlAttendanceInput.Controls.Add(this.btnSaveAttendance);
            this.pnlAttendanceInput.Controls.Add(this.dgvAttendanceInput);
            this.pnlAttendanceInput.Controls.Add(this.lblAttendanceInputTitle);
            this.pnlAttendanceInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAttendanceInput.Location = new System.Drawing.Point(0, 110);
            this.pnlAttendanceInput.Name = "pnlAttendanceInput";
            this.pnlAttendanceInput.Size = new System.Drawing.Size(800, 250);
            this.pnlAttendanceInput.TabIndex = 2;
            // 
            // btnSaveAttendance
            // 
            this.btnSaveAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAttendance.BackColor = System.Drawing.Color.Green;
            this.btnSaveAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAttendance.ForeColor = System.Drawing.Color.White;
            this.btnSaveAttendance.Location = new System.Drawing.Point(673, 210);
            this.btnSaveAttendance.Name = "btnSaveAttendance";
            this.btnSaveAttendance.Size = new System.Drawing.Size(115, 30);
            this.btnSaveAttendance.TabIndex = 2;
            this.btnSaveAttendance.Text = "Lưu điểm danh";
            this.btnSaveAttendance.UseVisualStyleBackColor = false;
            this.btnSaveAttendance.Click += new System.EventHandler(this.btnSaveAttendance_Click);
            // 
            // dgvAttendanceInput
            // 
            this.dgvAttendanceInput.AllowUserToAddRows = false;
            this.dgvAttendanceInput.AllowUserToDeleteRows = false;
            this.dgvAttendanceInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAttendanceInput.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendanceInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceInput.Location = new System.Drawing.Point(12, 36);
            this.dgvAttendanceInput.Name = "dgvAttendanceInput";
            this.dgvAttendanceInput.Size = new System.Drawing.Size(776, 168);
            this.dgvAttendanceInput.TabIndex = 1;
            // 
            // lblAttendanceInputTitle
            // 
            this.lblAttendanceInputTitle.AutoSize = true;
            this.lblAttendanceInputTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendanceInputTitle.Location = new System.Drawing.Point(12, 10);
            this.lblAttendanceInputTitle.Name = "lblAttendanceInputTitle";
            this.lblAttendanceInputTitle.Size = new System.Drawing.Size(153, 20);
            this.lblAttendanceInputTitle.TabIndex = 0;
            this.lblAttendanceInputTitle.Text = "Nhập điểm danh:";
            // 
            // pnlAttendanceView
            // 
            this.pnlAttendanceView.Controls.Add(this.dgvAttendance);
            this.pnlAttendanceView.Controls.Add(this.lblAttendanceViewTitle);
            this.pnlAttendanceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttendanceView.Location = new System.Drawing.Point(0, 360);
            this.pnlAttendanceView.Name = "pnlAttendanceView";
            this.pnlAttendanceView.Size = new System.Drawing.Size(800, 240);
            this.pnlAttendanceView.TabIndex = 3;
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendance.Location = new System.Drawing.Point(12, 36);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            this.dgvAttendance.Size = new System.Drawing.Size(776, 192);
            this.dgvAttendance.TabIndex = 1;
            // 
            // lblAttendanceViewTitle
            // 
            this.lblAttendanceViewTitle.AutoSize = true;
            this.lblAttendanceViewTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendanceViewTitle.Location = new System.Drawing.Point(12, 10);
            this.lblAttendanceViewTitle.Name = "lblAttendanceViewTitle";
            this.lblAttendanceViewTitle.Size = new System.Drawing.Size(164, 20);
            this.lblAttendanceViewTitle.TabIndex = 0;
            this.lblAttendanceViewTitle.Text = "Lịch sử điểm danh:";
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlAttendanceView);
            this.Controls.Add(this.pnlAttendanceInput);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AttendanceForm";
            this.Text = "Quản lý điểm danh";
            this.pnlHeader.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlAttendanceInput.ResumeLayout(false);
            this.pnlAttendanceInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceInput)).EndInit();
            this.pnlAttendanceView.ResumeLayout(false);
            this.pnlAttendanceView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cboSchedules;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.ComboBox cboClasses;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Panel pnlAttendanceInput;
        private System.Windows.Forms.Button btnSaveAttendance;
        private System.Windows.Forms.DataGridView dgvAttendanceInput;
        private System.Windows.Forms.Label lblAttendanceInputTitle;
        private System.Windows.Forms.Panel pnlAttendanceView;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Label lblAttendanceViewTitle;
    }
}




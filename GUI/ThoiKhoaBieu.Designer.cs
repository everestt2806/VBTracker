namespace VBTracker.GUI
{
    partial class ThoiKhoaBieu
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
            timetablePanel = new TableLayoutPanel();
            btnPreviousWeek = new Button();
            btnNextWeek = new Button();
            lblDate = new Label();
            headerPanel = new Panel();
            lblTitle = new Label();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(btnPreviousWeek);
            headerPanel.Controls.Add(lblDate);
            headerPanel.Controls.Add(btnNextWeek);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(4, 3, 4, 3);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(12);
            headerPanel.Size = new Size(1401, 41);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Maroon;
            lblTitle.Location = new Point(20, 10);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(399, 16);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Xem thời khóa biểu theo tuần | See the weekly schedule";
            // 
            // timetablePanel
            // 
            timetablePanel.BackColor = Color.WhiteSmoke;
            timetablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            timetablePanel.ColumnCount = 8;
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            timetablePanel.Location = new Point(0, 41);
            timetablePanel.Margin = new Padding(0);
            timetablePanel.Name = "timetablePanel";
            timetablePanel.RowCount = 17;
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            timetablePanel.Size = new Size(1401, 896);
            timetablePanel.TabIndex = 1;
            timetablePanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            // 
            // btnPreviousWeek
            // 
            btnPreviousWeek.BackColor = Color.RoyalBlue;
            btnPreviousWeek.FlatAppearance.BorderSize = 0;
            btnPreviousWeek.FlatStyle = FlatStyle.Flat;
            btnPreviousWeek.ForeColor = Color.White;
            btnPreviousWeek.Location = new Point(688, 6);
            btnPreviousWeek.Margin = new Padding(4, 3, 4, 3);
            btnPreviousWeek.Name = "btnPreviousWeek";
            btnPreviousWeek.Size = new Size(211, 24);
            btnPreviousWeek.TabIndex = 1;
            btnPreviousWeek.Text = "<< Tuần trước|Previous week";
            btnPreviousWeek.UseVisualStyleBackColor = false;
            btnPreviousWeek.Click += BtnPreviousWeek_Click;
            // 
            // btnNextWeek
            // 
            btnNextWeek.BackColor = Color.RoyalBlue;
            btnNextWeek.FlatAppearance.BorderSize = 0;
            btnNextWeek.FlatStyle = FlatStyle.Flat;
            btnNextWeek.ForeColor = Color.White;
            btnNextWeek.Location = new Point(1079, 0);
            btnNextWeek.Margin = new Padding(4, 3, 4, 3);
            btnNextWeek.Name = "btnNextWeek";
            btnNextWeek.Size = new Size(209, 24);
            btnNextWeek.TabIndex = 3;
            btnNextWeek.Text = "Tuần sau|Following week >>";
            btnNextWeek.UseVisualStyleBackColor = false;
            btnNextWeek.Click += BtnNextWeek_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Arial", 10F);
            lblDate.Location = new Point(907, 9);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(164, 16);
            lblDate.TabIndex = 2;
            lblDate.Text = "21/04/2025 - 27/04/2025";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ThoiKhoaBieu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1401, 937);
            Controls.Add(timetablePanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle; // Thêm thuộc tính này để form có kích thước cố định
            MaximizeBox = false; // Không cho phép phóng to
            Margin = new Padding(4, 3, 4, 3);
            Name = "ThoiKhoaBieu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thời khóa biểu theo tuần";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel timetablePanel;
        private System.Windows.Forms.Button btnPreviousWeek;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
    }
}
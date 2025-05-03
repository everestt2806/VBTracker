namespace VBTracker.GUI.LecturerArea.LecturerChildForm
{
    partial class ManageClassesForm
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
            this.classList = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // classList
            // 
            this.classList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classList.Location = new System.Drawing.Point(20, 20);
            this.classList.Name = "classList";
            this.classList.Size = new System.Drawing.Size(750, 300);
            this.classList.TabIndex = 0;

            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.Location = new System.Drawing.Point(20, 340);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(150, 40);
            this.btnViewDetails.Text = "Xem chi tiết";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.BtnViewDetails_Click);

            // 
            // ManageClassesForm
            // 
            this.Controls.Add(this.classList);
            this.Controls.Add(this.btnViewDetails);
            this.Name = "ManageClassesForm";
            this.Size = new System.Drawing.Size(800, 400);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView classList;
        private System.Windows.Forms.Button btnViewDetails;

        #endregion
    }
}
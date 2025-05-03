namespace VBTracker.GUI.LecturerArea
{
    partial class LecturerMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LecturerMainForm));
            menu = new Panel();
            bill_generate = new FontAwesome.Sharp.IconButton();
            menu_placeorder = new FontAwesome.Sharp.IconButton();
            menu_orders = new FontAwesome.Sharp.IconButton();
            menu_products = new FontAwesome.Sharp.IconButton();
            menu_employ = new FontAwesome.Sharp.IconButton();
            menu_clients = new FontAwesome.Sharp.IconButton();
            menu_dashboard = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            title_bar = new Panel();
            childFormTitle = new Label();
            iconChildform = new FontAwesome.Sharp.IconPictureBox();
            mainPanel = new Panel();
            menu.SuspendLayout();
            title_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconChildform).BeginInit();
            SuspendLayout();
            // 
            // menu
            // 
            menu.BackColor = Color.FromArgb(154, 178, 242);
            menu.Controls.Add(bill_generate);
            menu.Controls.Add(menu_placeorder);
            menu.Controls.Add(menu_orders);
            menu.Controls.Add(menu_products);
            menu.Controls.Add(menu_employ);
            menu.Controls.Add(menu_clients);
            menu.Controls.Add(menu_dashboard);
            menu.Controls.Add(panel1);
            menu.Dock = DockStyle.Left;
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(291, 1024);
            menu.TabIndex = 0;
            // 
            // bill_generate
            // 
            bill_generate.BackColor = Color.FromArgb(154, 178, 242);
            bill_generate.Dock = DockStyle.Top;
            bill_generate.FlatAppearance.BorderSize = 0;
            bill_generate.FlatStyle = FlatStyle.Flat;
            bill_generate.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bill_generate.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            bill_generate.IconColor = Color.Black;
            bill_generate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            bill_generate.IconSize = 32;
            bill_generate.ImageAlign = ContentAlignment.MiddleLeft;
            bill_generate.Location = new Point(0, 722);
            bill_generate.Name = "bill_generate";
            bill_generate.Size = new Size(291, 97);
            bill_generate.TabIndex = 7;
            bill_generate.Text = "Bill Generator";
            bill_generate.TextImageRelation = TextImageRelation.ImageBeforeText;
            bill_generate.UseVisualStyleBackColor = false;
            bill_generate.Click += bill_generate_Click_1;
            // 
            // menu_placeorder
            // 
            menu_placeorder.BackColor = Color.FromArgb(154, 178, 242);
            menu_placeorder.Dock = DockStyle.Top;
            menu_placeorder.FlatAppearance.BorderSize = 0;
            menu_placeorder.FlatStyle = FlatStyle.Flat;
            menu_placeorder.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menu_placeorder.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            menu_placeorder.IconColor = Color.Black;
            menu_placeorder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menu_placeorder.IconSize = 32;
            menu_placeorder.ImageAlign = ContentAlignment.MiddleLeft;
            menu_placeorder.Location = new Point(0, 625);
            menu_placeorder.Name = "menu_placeorder";
            menu_placeorder.Size = new Size(291, 97);
            menu_placeorder.TabIndex = 6;
            menu_placeorder.Text = "Place Order";
            menu_placeorder.TextImageRelation = TextImageRelation.ImageBeforeText;
            menu_placeorder.UseVisualStyleBackColor = false;
            menu_placeorder.Click += menu_placeorder_Click;
            // 
            // menu_orders
            // 
            menu_orders.BackColor = Color.FromArgb(154, 178, 242);
            menu_orders.Dock = DockStyle.Top;
            menu_orders.FlatAppearance.BorderSize = 0;
            menu_orders.FlatStyle = FlatStyle.Flat;
            menu_orders.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menu_orders.IconChar = FontAwesome.Sharp.IconChar.Shopify;
            menu_orders.IconColor = Color.Black;
            menu_orders.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menu_orders.IconSize = 32;
            menu_orders.ImageAlign = ContentAlignment.MiddleLeft;
            menu_orders.Location = new Point(0, 528);
            menu_orders.Name = "menu_orders";
            menu_orders.Size = new Size(291, 97);
            menu_orders.TabIndex = 5;
            menu_orders.Text = "Manage Orders";
            menu_orders.TextImageRelation = TextImageRelation.ImageBeforeText;
            menu_orders.UseVisualStyleBackColor = false;
            menu_orders.Click += menu_orders_Click;
            // 
            // menu_products
            // 
            menu_products.BackColor = Color.FromArgb(154, 178, 242);
            menu_products.Dock = DockStyle.Top;
            menu_products.FlatAppearance.BorderSize = 0;
            menu_products.FlatStyle = FlatStyle.Flat;
            menu_products.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menu_products.IconChar = FontAwesome.Sharp.IconChar.Cubes;
            menu_products.IconColor = Color.Black;
            menu_products.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menu_products.IconSize = 32;
            menu_products.ImageAlign = ContentAlignment.MiddleLeft;
            menu_products.Location = new Point(0, 431);
            menu_products.Name = "menu_products";
            menu_products.Size = new Size(291, 97);
            menu_products.TabIndex = 4;
            menu_products.Text = "Manage Products";
            menu_products.TextImageRelation = TextImageRelation.ImageBeforeText;
            menu_products.UseVisualStyleBackColor = false;
            menu_products.Click += menu_products_Click;
            // 
            // menu_employ
            // 
            menu_employ.BackColor = Color.FromArgb(154, 178, 242);
            menu_employ.Dock = DockStyle.Top;
            menu_employ.FlatAppearance.BorderSize = 0;
            menu_employ.FlatStyle = FlatStyle.Flat;
            menu_employ.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menu_employ.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            menu_employ.IconColor = Color.Black;
            menu_employ.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menu_employ.IconSize = 32;
            menu_employ.ImageAlign = ContentAlignment.MiddleLeft;
            menu_employ.Location = new Point(0, 334);
            menu_employ.Name = "menu_employ";
            menu_employ.Size = new Size(291, 97);
            menu_employ.TabIndex = 3;
            menu_employ.Text = "Manage Employees";
            menu_employ.TextImageRelation = TextImageRelation.ImageBeforeText;
            menu_employ.UseVisualStyleBackColor = false;
            menu_employ.Click += menu_employ_Click;
            // 
            // menu_clients
            // 
            menu_clients.BackColor = Color.FromArgb(154, 178, 242);
            menu_clients.Dock = DockStyle.Top;
            menu_clients.FlatAppearance.BorderSize = 0;
            menu_clients.FlatStyle = FlatStyle.Flat;
            menu_clients.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menu_clients.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            menu_clients.IconColor = Color.Black;
            menu_clients.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menu_clients.IconSize = 32;
            menu_clients.ImageAlign = ContentAlignment.MiddleLeft;
            menu_clients.Location = new Point(0, 237);
            menu_clients.Name = "menu_clients";
            menu_clients.Size = new Size(291, 97);
            menu_clients.TabIndex = 2;
            menu_clients.Text = "Manage Clients";
            menu_clients.TextImageRelation = TextImageRelation.ImageBeforeText;
            menu_clients.UseVisualStyleBackColor = false;
            menu_clients.Click += menu_clients_Click;
            // 
            // menu_dashboard
            // 
            menu_dashboard.BackColor = Color.FromArgb(154, 178, 242);
            menu_dashboard.Dock = DockStyle.Top;
            menu_dashboard.FlatAppearance.BorderSize = 0;
            menu_dashboard.FlatStyle = FlatStyle.Flat;
            menu_dashboard.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menu_dashboard.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            menu_dashboard.IconColor = Color.Black;
            menu_dashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menu_dashboard.IconSize = 32;
            menu_dashboard.ImageAlign = ContentAlignment.MiddleLeft;
            menu_dashboard.Location = new Point(0, 140);
            menu_dashboard.Name = "menu_dashboard";
            menu_dashboard.Size = new Size(291, 97);
            menu_dashboard.TabIndex = 1;
            menu_dashboard.Text = "Timetable";
            menu_dashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            menu_dashboard.UseVisualStyleBackColor = false;
            menu_dashboard.Click += menu_dashboard_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(291, 140);
            panel1.TabIndex = 0;
            // 
            // title_bar
            // 
            title_bar.BackColor = Color.CornflowerBlue;
            title_bar.Controls.Add(childFormTitle);
            title_bar.Controls.Add(iconChildform);
            title_bar.Dock = DockStyle.Top;
            title_bar.Location = new Point(291, 0);
            title_bar.Name = "title_bar";
            title_bar.Size = new Size(1407, 70);
            title_bar.TabIndex = 1;
            // 
            // childFormTitle
            // 
            childFormTitle.AutoSize = true;
            childFormTitle.Font = new Font("Britannic Bold", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            childFormTitle.ForeColor = Color.FromArgb(49, 24, 96);
            childFormTitle.Location = new Point(599, 13);
            childFormTitle.Name = "childFormTitle";
            childFormTitle.Size = new Size(85, 30);
            childFormTitle.TabIndex = 1;
            childFormTitle.Text = "label1";
            childFormTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // iconChildform
            // 
            iconChildform.BackColor = Color.CornflowerBlue;
            iconChildform.ForeColor = Color.FromArgb(49, 24, 96);
            iconChildform.IconChar = FontAwesome.Sharp.IconChar.None;
            iconChildform.IconColor = Color.FromArgb(49, 24, 96);
            iconChildform.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconChildform.IconSize = 50;
            iconChildform.Location = new Point(20, 12);
            iconChildform.Name = "iconChildform";
            iconChildform.Size = new Size(50, 50);
            iconChildform.TabIndex = 0;
            iconChildform.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(291, 70);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1407, 954);
            mainPanel.TabIndex = 2;
            // 
            // Management_Form
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(184, 201, 255);
            ClientSize = new Size(1698, 1024);
            Controls.Add(mainPanel);
            Controls.Add(title_bar);
            Controls.Add(menu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Management_Form";
            Text = "VB Tracker";
            Load += Management_Form_Load;
            menu.ResumeLayout(false);
            title_bar.ResumeLayout(false);
            title_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconChildform).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton menu_dashboard;
        private FontAwesome.Sharp.IconButton menu_products;
        private FontAwesome.Sharp.IconButton menu_employ;
        private FontAwesome.Sharp.IconButton menu_clients;
        private FontAwesome.Sharp.IconButton menu_placeorder;
        private FontAwesome.Sharp.IconButton menu_orders;
        private System.Windows.Forms.Panel title_bar;
        private System.Windows.Forms.Label childFormTitle;
        private FontAwesome.Sharp.IconPictureBox iconChildform;
        private System.Windows.Forms.Panel mainPanel;
        private FontAwesome.Sharp.IconButton bill_generate;
    }
}
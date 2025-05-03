using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;
using VBTracker.GUI;


namespace VBTracker.GUI.StudentArea
{
    public partial class StudentMainForm : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentForm;
        public static Color leftBorderColor = Color.FromArgb(49, 24, 96);
        public StudentMainForm()
        {
            InitializeComponent();
        }

        private void Management_Form_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        private void formLoad(){
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            menu.Controls.Add(leftBorderBtn);
            activateBtn(menu_dashboard, leftBorderColor);
            openChildForm(new ThoiKhoaBieu());
        }

        private void openChildForm(Form childForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            childForm.Text = childFormTitle.Text;
        }

        private void activateBtn(object senderBtn, System.Drawing.Color color) {
            if (senderBtn != null)
            {
                disableBtn();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.FromArgb(125, 151, 255);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.Height = currentBtn.Height;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconChildform.IconChar = currentBtn.IconChar;
                iconChildform.IconColor = color;
                childFormTitle.Text = currentBtn.Text;

            }
        }
 
        private void disableBtn() {
            if (currentBtn != null) {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(154, 178, 242);
                currentBtn.ForeColor = System.Drawing.Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.Black; 
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

       

        private void menu_clients_Click(object sender, EventArgs e)
        {
            activateBtn(sender, leftBorderColor);
            openChildForm(new ThoiKhoaBieu());
        }

        private void menu_employ_Click(object sender, EventArgs e)
        {
            activateBtn(sender, leftBorderColor);
            openChildForm(new ThoiKhoaBieu());
        }

        private void menu_products_Click(object sender, EventArgs e)
        {
            activateBtn(sender, leftBorderColor);
            openChildForm(new ThoiKhoaBieu());
        }

        private void menu_orders_Click(object sender, EventArgs e)
        {
            activateBtn(sender, leftBorderColor);
            openChildForm(new ThoiKhoaBieu());
        }


        private void bill_generate_Click_1(object sender, EventArgs e)
        {
            activateBtn(sender, leftBorderColor);
            openChildForm(new ThoiKhoaBieu());

        }

        private void menu_placeorder_Click(object sender, EventArgs e)
        {
            activateBtn(sender, leftBorderColor);
            openChildForm(new ThoiKhoaBieu());
        }

        private void menu_dashboard_Click(object sender, EventArgs e)
        {
            activateBtn(sender, leftBorderColor);
            openChildForm(new ThoiKhoaBieu());
        }
    }
}

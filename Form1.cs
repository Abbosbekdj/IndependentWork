using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndependentWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void customizeDesign()
        {
            panel_productsubmenu.Visible = false;
            panel_usersubmenu.Visible = false;
            panel_ordersubmenu.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panel_productsubmenu.Visible==true)
            {
                panel_productsubmenu.Visible = false;
            }
            if (panel_usersubmenu.Visible == true)
            {
                panel_usersubmenu.Visible = false;
            }
            if (panel_ordersubmenu.Visible == true)
            {
                panel_ordersubmenu.Visible = false;
            }
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        #region Product Submenu
        private void button_products_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_productsubmenu);
        }

        private void btn_addproduct_Click(object sender, EventArgs e)
        {
            openForm2(new Form2());
            hideSubmenu();
            //Form form2 = new Form2();
            //form2.Show();
        }

        private void btn_viewproduct_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_updateproduct_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_printproduct_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        #endregion Product Submenu

        #region User Submenu
        private void button_users_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_usersubmenu);
        }

        private void btn_adduser_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_viewuser_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_updateuser_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_printuser_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        # endregion User Submenu

        #region Order Submenu
        private void button_orders_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_ordersubmenu);
        }

        private void btn_allorder_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_deliviredorder_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_undeliviredorder_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btn_printorder_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        # endregion Order Submenu

        // submenudagi maxsulot qoshish tugmasi bosilgand form2 ni chiqarish form1 shablonida

        private Form activeForm = null;
        private void openForm2(Form form2)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = form2;
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            panel_main.Controls.Add(form2);
            panel_main.Tag = form2;
            form2.BringToFront();
            form2.Show();
        }
    }
}

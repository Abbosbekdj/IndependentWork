using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;

namespace IndependentWork
{
    public partial class Form2 : Form
    {
        Product product = new Product();
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            // rasm yuklash jarayoni
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                product_img.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            // yangi maxsulot qo'shish
          
            string pname = product_name.Text;
            string pcount = product_count.Text;
            string pbrand = product_brand.Text;
            string pprice = product_price.Text;
            //DateTime pdate = dateTimePicker1.Value.Date;
            byte[] pimg;
            using (var ms = new MemoryStream())
            {
                product_img.Image.Save(ms, product_img.Image.RawFormat);
                pimg = ms.ToArray();
            };

            //int product_year = dateTimePicker1.Value.Year;
            //int this_year = DateTime.Now.Year;
            //if ((this_year - product_year) < 10 || (this_year - product_year) > 100)
            //if (product_year != null)
            //{
            //    MessageBox.Show("Iltimos yilni to'g'ri tanlang siz tanlagan yil noto'g'ri ",
            //        "Maxsulot yilini kiritshda xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            if (verify())
            {
                if (product.insertProduct(pname, pcount, pbrand, pprice, pimg))
                {
                    MessageBox.Show("Yangi maxsulot qo'shildi", "Maxsulot qo'shildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                else
                {
                    MessageBox.Show("Nimadur", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Qaysidir maydon to'ldirilmadi", "Maxsulot qo'shildi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            

        }

        bool verify()
        {
            if ( (product_name.Text == "") || (product_count.Text == "") || 
                (product_brand.Text == "") || (product_price.Text == "") || (product_img.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            product_name.Clear();
            product_brand.Clear();
            product_count.Clear();
            product_price.Clear();
            product_img.Image = null;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            showTable();
        }
        private void showTable()
        {
            product_data_view.DataSource=product.getproductlist();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)product_data_view.Columns[5];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    }
}

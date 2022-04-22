using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Store_project
{
    public partial class Form1 : Form
    {
    public Form1()
        {
            InitializeComponent();
        }

    public double Price_of_Product()
        {
            Double sum = 0;
            int i = 0;

            for (i = 0; i < (dataGridView1.Rows.Count);
            i++)
           {
            sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
           }
            return sum;
        }

        private void AddPrice()
        {
            Double tax, q;
            tax = 3.9;
            if (dataGridView1.Rows.Count >0)
            {
                lbTexB.Text = String.Format("{0:c2}", (((Price_of_Product() * tax) / 100)));
                lbSubB.Text = String.Format ("{0:c2}", (Price_of_Product()));
                q = ((Price_of_Product ()*tax) / 100);
                lbTotalB .Text =String .Format ("{0:c2}",((Price_of_Product ()) + q)); 
                lbBarcode .Text = Convert .ToString(q+Price_of_Product ());
            }
        }

        private void Change()
        {
            Double tax, q, c;
            tax = 3.9;
            if (dataGridView1.Rows.Count > 0)
            {
                q = ((Price_of_Product() * tax) / 100) + Price_of_Product ();
                c = Convert.ToInt32(lbTotalB.Text);
                lbChangeB.Text = String.Format("{0:c2}", c - q);
            }
        }

        Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            { 
                int heigth = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = heigth;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                lbBarcode.Text = "";
                lbPriceB.Text = "0";
                lbChangeB.Text = "";
                lbSubB.Text = "";
                lbTexB.Text = "";
                lbTotalB.Text = "";
                dataGridView1 .Rows.Clear ();
                dataGridView1.Refresh();
                cboPayment.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPayment.Items.Add("cash");
            cboPayment.Items.Add("PromptPay");
        }

        private void NumbersOnly(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (lbPriceB.Text == "0")
            {
                lbPriceB.Text = "";
                lbPriceB.Text = b.Text;
            }
            else if (b.Text == ("."))
            {
                if (!b.Text.Contains(".")) 
                {
                    lbPriceB.Text = lbPriceB.Text + b.Text;
                }
            }
        }
       
        private void btnClear_Click(object sender,EventArgs e)
        {
            lbPriceB.Text = "0";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lbChangeB.Text = "";
                lbPriceB.Text = "0";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1 .SelectedRows )
            {
                dataGridView1 .Rows.Remove (row);
            }
            AddPrice();
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lbChangeB.Text = "";
                lbPriceB.Text = "0";
            }
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
            Double Price_Product = 10;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
               if ((bool)(row.Cells [0].Value = "สบู่ลักซ์"))
                {
                    row.Cells[1].Value = Double.Parse ((string)row.Cells [1].Value +1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            } 
            dataGridView1.Rows.Add ("Lux Soap", "1", Price_Product );
            AddPrice();
        }

        private void btnP4_Click(object sender, EventArgs e)
        {
            Double Price_Product = 35;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "แบรนด์ซุปไก่"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            }
            dataGridView1.Rows.Add("แบรนด์ซุปไก่", "1", Price_Product);
            AddPrice();
        }

        private void btnP2_Click(object sender, EventArgs e)
        {
            Double Price_Product = 20;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "มันฝรั่งเทสโต้"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            }
            dataGridView1.Rows.Add("มันฝรั่งเทสโต้", "1", Price_Product);
            AddPrice();
        }

        private void btnP3_Click(object sender, EventArgs e)
        {
            Double Price_Product = 12;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "โฟร์โมสต์รสจืด"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            }
            dataGridView1.Rows.Add("โฟร์โมสต์รสจืด", "1", Price_Product);
            AddPrice();
        }

        private void btnP5_Click(object sender, EventArgs e)
        {
            Double Price_Product = 39;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "สก๊อตรังนก"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            }
            dataGridView1.Rows.Add("สก๊อตรังนก", "1", Price_Product);
            AddPrice();
        }

        private void btnP6_Click(object sender, EventArgs e)
        {
            Double Price_Product = 30;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "แป้งแคร์"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            }
            dataGridView1.Rows.Add("แป้งแคร์", "1", Price_Product);
            AddPrice();
        }

        private void btnP7_Click(object sender, EventArgs e)
        {
            Double Price_Product = 20;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "โออิชิรสน้ำผึ้งมะนาว"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            }
            dataGridView1.Rows.Add("โออิชิรสน้ำผึ้งมะนาว", "1", Price_Product);
            AddPrice();
        }

        private void btnP8_Click(object sender, EventArgs e)
        {
            Double Price_Product = 25;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "คิทแคท"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            }
            dataGridView1.Rows.Add("คิดแคท", "1", Price_Product);
            AddPrice();
        }

        private void btnP9_Click(object sender, EventArgs e)
        {
            Double Price_Product = 10;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "เบง-เบง"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * Price_Product;

                }
            }
            dataGridView1.Rows.Add("เบง-เบง", "1", Price_Product);
            AddPrice();
        }
    }
}

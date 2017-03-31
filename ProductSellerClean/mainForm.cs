using System;
using System.Windows.Forms;

namespace ProductSellerClean
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            if(Data.List.Count > 0)
            {
                foreach (Product temp in Data.List)
                {
                    listView.Items.Add(temp.item());
                    Data.GetLastId = temp.Id;
                }
            }
            else
            {
                Data.GetLastId = 0;
                Data.Id = 1;
            }

            if (Data.Id == Data.GetLastId)
                Data.Id++;
            else
                Data.Id = Data.GetLastId + 1;

            txtID.Text = Data.Id + "";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ViewProduct().Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Data.Id;
                string pname = txtPname.Text.Trim();
                int qty = int.Parse(txtQty.Text);
                double uprice = double.Parse(txtPrice.Text);
                
                Product product = new Product(id, pname, qty, uprice);

                Data.List.Add(product);
                listView.Items.Add(product.item());

                Data.Id++;
                txtID.Text = Data.Id + "";

                txtPname.Clear();
                txtQty.Clear();
                txtPrice.Clear();

            }
            catch (Exception)
            {
                MessageBox.Show("Please check your fills again!!!");
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

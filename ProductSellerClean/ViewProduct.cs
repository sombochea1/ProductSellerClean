using System;
using System.Windows.Forms;

namespace ProductSellerClean
{
    public partial class ViewProduct : Form
    {
        public ViewProduct()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new mainForm().Show();
        }

        private void ViewProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ViewProduct_Load(object sender, EventArgs e)
        {
            if(Data.List.Count > 0)
            {
                foreach (Product temp in Data.List)
                    listView.Items.Add(temp.item());
            }
            
        }

        ListViewItem item_selected;
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView.SelectedItems.Count == 0)
            {
                txtID.Clear();
                txtPname.Clear();
                txtQty.Clear();
                txtPrice.Clear();

                txtPname.Enabled = false;
                txtQty.Enabled = false;
                txtPrice.Enabled = false;

                return;
            }

            item_selected = listView.SelectedItems[0];
            txtID.Text = item_selected.Text;
            txtPname.Text = item_selected.SubItems[1].Text;
            txtQty.Text = item_selected.SubItems[2].Text;
            txtPrice.Text = item_selected.SubItems[3].Text;

            txtPname.Enabled = true;
            txtQty.Enabled = true;
            txtPrice.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int index = -1;
                if (listView.SelectedItems.Count > 0)
                    index = listView.Items.IndexOf(listView.SelectedItems[0]);

                int id = int.Parse(txtID.Text);
                string pname = txtPname.Text.Trim();
                int qty = int.Parse(txtQty.Text);
                double uprice = double.Parse(txtPrice.Text);

                Product up_product = new Product(id, pname, qty, uprice);

                if ( index != -1)
                {
                    Data.List[index] = up_product; //Replace Item of Index to List
                    listView.Items.RemoveAt(index); //Remove Item at Index from ListView
                    listView.Items.Insert(index, up_product.item()); //Replace Item of Index to ListView

                }

                txtID.Clear();
                txtPname.Clear();
                txtQty.Clear();
                txtPrice.Clear();

            }
            catch (Exception)
            {
                MessageBox.Show("Please check your fills again!!!");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem temp in listView.SelectedItems)
            {
                int index = temp.Index;
                Data.List.RemoveAt(index);
                listView.Items.Remove(temp);
            }

            //if (listView.Items.Count == 0)
            //{
            //    Data.GetLastId = 0;
            //    Data.Id = 1;
            //}
            //else
            //{
            //    foreach (ListViewItem temp in listView.Items)
            //        Data.GetLastId = int.Parse(temp.Text);
            //}

            txtID.Clear();
            txtPname.Clear();
            txtQty.Clear();
            txtPrice.Clear();
        }
    }
}

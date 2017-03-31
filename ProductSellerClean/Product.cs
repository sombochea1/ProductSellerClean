using System.Windows.Forms;

namespace ProductSellerClean
{
    class Product
    {
        private int _id;
        private string _pname;
        private int _qty;
        private double _uprice;

        public int Id { get => _id; set => _id = value; }
        public string Pname { get => _pname; set => _pname = value; }
        public int Qty { get => _qty; set => _qty = value; }
        public double Uprice { get => _uprice; set => _uprice = value; }

        public double Amount()
        {
            return Qty * Uprice;
        }

        public Product()
        {

        }
        public Product(int id, string pname, int qty, double uprice)
        {
            Id = id;
            Pname = pname;
            Qty = qty;
            Uprice = uprice;
        }

        public ListViewItem item()
        {
            string[] data = {Id.ToString("000"),Pname,Qty+"",Uprice+"",Amount().ToString("$#,##0.00")};
            return new ListViewItem(data);
        }
    }
}

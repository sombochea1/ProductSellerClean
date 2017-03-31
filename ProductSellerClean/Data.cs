using System.Collections.Generic;

namespace ProductSellerClean
{
    static class Data
    {
        private static List<Product> list = new List<Product>();
        private static int _id;
        private static int _getLastId;

        public static List<Product> List { get => list; set => list = value; }
        public static int Id { get => _id; set => _id = value; }
        public static int GetLastId { get => _getLastId; set => _getLastId = value; }
    }
}

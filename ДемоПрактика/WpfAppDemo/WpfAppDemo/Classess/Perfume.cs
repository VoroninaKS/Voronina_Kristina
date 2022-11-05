using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfAppDemo.Classess
{
    public class Perfume
    {
        public string Product_category { get; set; }

        public int Current_discount { get; set; }

        public int Quantity_in_stock { get; set; }

        public string Description {get;set;}

        public BitmapImage Image { get; set; }

        public Perfume (string product_category, int current_discount, int quantity_in_stock, string description, BitmapImage image)
        {
            Product_category = product_category;
            Current_discount = current_discount;
            Quantity_in_stock = quantity_in_stock;
            Description = description;
            Image = image;
        }
    }
}

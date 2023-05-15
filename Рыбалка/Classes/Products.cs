using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рыбалка.Classes
{
    public class Products
    {
        public string article { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string img { get; set; }
        public string manufacturer { get; set; }
        public string cost { get; set; }
        public string discount { get; set; }
        public string count { get; set; }
        public string postavschik { get; set; }

        public Products(string _article, string _name, string _description, string _category, string _img, string _manufacturer, string _cost, string _discount, string _count, string _postavschik)
        {
            article = _article;
            name = _name;
            description = _description;
            category = _category;
            img = _img;
            manufacturer = _manufacturer;
            cost = _cost;
            discount = _discount;
            count = _count;
            postavschik = _postavschik;
        }
    }

}

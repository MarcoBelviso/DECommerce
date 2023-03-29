using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public int ProductCategoriesID { get; set; }
        public int? UnitPrice { get; set; }
        public string? Image { get; set; }
        public string? Field1 { get; set; }
        public string? Field2 { get; set; }
        public int? Field3 { get; set; }
        public int? Field4 { get; set; }

       

        //-------------------------------------------//Relazioni tra tabelle
        public ProductCategories ProductCategories { get; set; }
        public List<OrderDetails> OrderDetails { get; set;}
        
    }
}

using System.ComponentModel.DataAnnotations;

namespace DECommerce.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Field1 { get; set; }
        public string? Field2 { get; set; }

        //-------------------------------------------//Relazioni tra tabelle
        public Orders Orders { get; set; }
        public Products Products { get; set; }

    }
}
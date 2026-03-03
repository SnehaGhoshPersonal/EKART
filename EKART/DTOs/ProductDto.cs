using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EKART.Models
{
    public class ProductDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public int? QuantityPerUnit { get; set; }

        public int? UnitPrice { get; set; }

        public int? UnitInStock { get; set; }

        public int? UnitsOnOrder { get; set; }

        public int? ReorderLevel { get; set; }

        public bool? Discontinued { get; set; }

    }
}

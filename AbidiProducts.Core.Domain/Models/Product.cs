using Microsoft.EntityFrameworkCore;

namespace AbidiProducts.Models
{
    [Index(nameof(ProductCode), IsUnique = true)]
    [Index(nameof(ProductName), IsUnique = true)]
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

    }
}

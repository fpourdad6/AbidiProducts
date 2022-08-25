using System.ComponentModel.DataAnnotations;

namespace AbidiProducts.Core.ApplicationService.Products.AddProduct.Dtos
{
    public class AddProductRequestDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public int UnitId { get; set; }
    }
}

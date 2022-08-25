using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AbidiProducts.Models
{
    public class ProductViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public int UnitId { get; set; }
    }
}

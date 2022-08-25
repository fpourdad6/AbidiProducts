using System.ComponentModel.DataAnnotations;

namespace AbidiProducts.Models
{
    public class UnitViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UnitName { get; set; }
       
    }
}

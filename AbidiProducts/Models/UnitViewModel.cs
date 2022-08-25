using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AbidiProducts.Models
{
    public class UnitViewModel
    {
        
        [Required]
        public int Id { get; set; }
        [Required]
        public string UnitName { get; set; }
        private List<Unit> _item = new();
        public IEnumerable<Unit> Items => _item;


    }
}

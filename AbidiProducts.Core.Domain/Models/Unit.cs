using Microsoft.EntityFrameworkCore;

namespace AbidiProducts.Models
{
    [Index(nameof(UnitName),Name = "IX_Unit_Name", IsUnique = true)]
    public class Unit
    {
        public int Id { get; set; }
        public string? UnitName { get; set; }
    }
}

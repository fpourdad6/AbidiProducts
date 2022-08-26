namespace AbidiProducts.Models
{
    public interface IUnitRepository
    {
        void AddUnit(string unitName);
        List<string> GetAllUnits();
        void UpdateUnit(int Id,string unitName);
        void DeleteUnit(int id);
    }
}

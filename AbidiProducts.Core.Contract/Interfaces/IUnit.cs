namespace AbidiProducts.Models
{
    public interface IUnitRepository
    {
        void AddUnit(string unitName);
        List<string> GetAllUnits();
        void UpdateUnit(int id);
        void DeleteUnit(int id);
    }
}

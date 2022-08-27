using Microsoft.Data.SqlClient;
using System.Web.Mvc;

namespace AbidiProducts.Models
{
    public class UnitRepository: IUnitRepository
    {
        private readonly ProductDbContext productDbContext;

        public UnitRepository(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public void AddUnit(string unitName)
        {
            var exist = productDbContext.Units.Where(x => x.UnitName == unitName).FirstOrDefault();
            try
            {
                if (exist == null)
                {
                    var entity = new Unit
                    {
                        UnitName = unitName
                    };
                    productDbContext.Units.Add(entity);
                    productDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw new ApplicationException("این واحد تکراری می باشد");
            }
            
        }
        public List<string> GetAllUnits() =>
          productDbContext.Units.Select(c => c.UnitName).ToList();

        [HttpPut]
        public void UpdateUnit(int id,string unitName)
        {
            try
            {
                var unit = productDbContext.Units.FirstOrDefault(x => x.Id == id);
                if (unit != null)
                {
                    unit.UnitName = unitName;
                    productDbContext.Units.Update(unit);
                    productDbContext.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("IX_Unit_Name"))
                {
                    throw new ApplicationException("نام واحد تکراری است");
                }
            }
        }
        public void DeleteUnit(int id)
        {
            var raw = productDbContext.Units.Where(c => c.Id == id).Select(c=>c).FirstOrDefault();
            try
            {
                if (raw != null && productDbContext.Products.Where(c => c.UnitId == id).Select(c=>c.UnitId).FirstOrDefault() != raw.Id)
                {
                    productDbContext.Remove(raw);
                    productDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw new ApplicationException("امکان حذف این واحد وجود ندارد");
            }
 
        }
       
    }
}

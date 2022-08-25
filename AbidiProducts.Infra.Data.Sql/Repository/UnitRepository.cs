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
            var entity = new Unit
            {
                UnitName = unitName
            };
            productDbContext.Units.Add(entity);
            productDbContext.SaveChanges();
        }
        public List<string> GetAllUnits() =>
          productDbContext.Units.Select(c => c.UnitName).ToList();

        [HttpPut]
        public void UpdateUnit(int id)
        {
            var x = productDbContext.Units.Where(c => c.Id == id).Select(c => c).First();
            var entity = new Unit
            {
                UnitName = x.UnitName,
            };
            productDbContext.Units.Update(entity);
            productDbContext.SaveChanges();
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

using Microsoft.Data.SqlClient;

namespace AbidiProducts.Models
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductDbContext productDbContext;
       
        public ProductRepository(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }
        public void AddProduct(string productCode,string productName,int qty,int unitId)
        {
            var pc = productDbContext.Products.Where(x => x.ProductCode == productCode && x.ProductName == productName).FirstOrDefault();
            try
            {
                if (pc == null)
                {
                    var entity = new Product
                    {
                        ProductCode = productCode,
                        ProductName = productName,
                        Qty = qty,
                        UnitId = unitId
                    };
                    productDbContext.Products.Add(entity);
                    productDbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw new ApplicationException("کالا با این مشخصات موجود می باشد");
            }

        }
        public List<Product> GetProducts()
        {
            return productDbContext.Products.Select(c=>c).ToList();
        }
        public void UpdateProduct(int id,string productCode, string productName, int qty, int unitId)
        {
            try
            {
                var pc = productDbContext.Products.FirstOrDefault(x => x.Id == id);
                if (pc != null)
                {
                    pc.ProductCode = productCode;
                    pc.ProductName = productName;
                    pc.Qty = qty;
                    pc.UnitId = unitId;
                    productDbContext.Products.Update(pc);
                    productDbContext.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("IX_Product_Code"))
                {
                    throw new ApplicationException("کد کالا تکراری است");
                }
                if (ex.Message.Contains("IX_Product_Name"))
                {
                    throw new ApplicationException("نام کالا تکراری است");
                }
            }
        }
        public void DeleteProduct(int id)
        {
            var row = productDbContext.Products.Where(c => c.Id == id).Select(c => c).FirstOrDefault();
            if (row != null)
            {
                productDbContext.Remove(row);
                productDbContext.SaveChanges();
            }
        }
    }
}

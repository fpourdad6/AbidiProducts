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
        public List<Product> GetProducts()
        {
            return productDbContext.Products.Select(c=>c).ToList();
        }
        public void UpdateProduct(int id)
        {
            var x = productDbContext.Products.Where(c => c.Id == id).Select(c=>c).First();
            var entity = new Product
            {
                ProductCode = x.ProductCode,
                ProductName = x.ProductName,
                Qty = x.Qty,
                UnitId = x.UnitId
            };
            productDbContext.Products.Update(entity);
            productDbContext.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var row = productDbContext.Products.Where(c => c.Id == id).Select(c => c).ToList();
            productDbContext.Remove(row);

        }
    }
}

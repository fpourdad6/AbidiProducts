namespace AbidiProducts.Models
{
    public interface IProductRepository
    {
        void AddProduct(string productCode,string productName, int qty,int unitId);
        List<Product> GetProducts();
        void UpdateProduct(int id,string productCode, string productName, int qty, int unitId);
        void DeleteProduct(int id);
    }
}

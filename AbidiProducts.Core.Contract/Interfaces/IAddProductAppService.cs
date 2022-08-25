using AbidiProducts.Core.ApplicationService.Products.AddProduct.Dtos;
namespace AbidiProducts.Core.ApplicationService.Products.AddProduct
{
    public interface IAddProductAppService
    {
        void Execute(AddProductRequestDto addProductRequestDto);
    }
}
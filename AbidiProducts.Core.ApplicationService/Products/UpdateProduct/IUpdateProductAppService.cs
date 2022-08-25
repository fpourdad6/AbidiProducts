using AbidiProducts.Core.ApplicationService.Products.UpdateProduct.Dtos;

namespace AbidiProducts.Core.ApplicationService.Products.UpdateProduct
{
    public interface IUpdateProductAppService
    {
        void Execute(UpdateProductRequestDto updateProductRequestDto);
    }
}
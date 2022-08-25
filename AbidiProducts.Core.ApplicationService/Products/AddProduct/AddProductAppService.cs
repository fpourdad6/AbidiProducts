using AbidiProducts.Core.ApplicationService.Products.AddProduct.Dtos;
using AbidiProducts.Models;

namespace AbidiProducts.Core.ApplicationService.Products.AddProduct
{
    public class AddProductAppService : IAddProductAppService
    {
        private readonly IProductRepository productRepository;

        public AddProductAppService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(AddProductRequestDto requestDto)
        {

            productRepository.AddProduct(requestDto.ProductCode, requestDto.ProductName,requestDto.Qty,requestDto.UnitId);
        }
    }
}

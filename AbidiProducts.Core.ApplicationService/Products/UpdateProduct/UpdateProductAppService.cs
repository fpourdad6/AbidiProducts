using AbidiProducts.Core.ApplicationService.Products.UpdateProduct.Dtos;
using AbidiProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbidiProducts.Core.ApplicationService.Products.UpdateProduct
{
    public class UpdateProductAppService:IUpdateProductAppService
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductAppService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public void Execute(UpdateProductRequestDto updateProductRequestDto)
        {
            _productRepository.UpdateProduct(updateProductRequestDto.Id,
                updateProductRequestDto.ProductCode,
                updateProductRequestDto.ProductName,
                updateProductRequestDto.Qty,
                updateProductRequestDto.UnitId);
        }
    }
}

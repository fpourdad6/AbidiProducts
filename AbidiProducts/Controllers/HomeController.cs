using AbidiProducts.Core.ApplicationService.Products.AddProduct;
using AbidiProducts.Core.ApplicationService.Products.AddProduct.Dtos;
using AbidiProducts.Core.ApplicationService.Products.UpdateProduct;
using AbidiProducts.Core.ApplicationService.Products.UpdateProduct.Dtos;
using AbidiProducts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AbidiProducts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext _productDbContext;
        private readonly IProductRepository _productRepo;
        private readonly IUnitRepository _unitRepository;

        public HomeController(ProductDbContext productDbContext, IProductRepository productRepo, IUnitRepository unitRepository)
        {
            this._productDbContext = productDbContext;
            this._productRepo = productRepo;
            this._unitRepository = unitRepository;
        }
        public IActionResult Index()
        {
            var units = _productDbContext.Units.ToList();
            ViewBag.subGroupNameList = units;
            var products = _productDbContext.Products.ToList();
            ViewBag.Products = products;
            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateEditProduct(int? id)
        {
            var dto = new ProductViewModel
            {
                Id = id ?? -1
            };

            if (id != null)
            {
                var products = _productDbContext.Products.Where(c => c.Id == id).Select(c => c).First();
                dto = new ProductViewModel
                {
                    Id = products.Id,
                    ProductCode = products.ProductCode,
                    ProductName = products.ProductName,
                    Qty = products.Qty,
                    UnitId = products.UnitId
                };
            }
            var units = _productDbContext.Units.ToList();
            ViewBag.subGroupNameList = units;
            return PartialView("_CreateEditProduct", dto);
        }

        [HttpPost]
        public IActionResult CreateEditProduct(ProductViewModel model, [FromServices] IAddProductAppService addProductAppService, [FromServices] IUpdateProductAppService updateProductAppService)
        {
            if (model.Id <= 0)
            {
                var requestDto = new AddProductRequestDto()
                {
                    ProductCode = model.ProductCode,
                    ProductName = model.ProductName,
                    Qty = model.Qty,
                    UnitId = model.UnitId
                };
                addProductAppService.Execute(requestDto);
            }
            else if (model.Id > 0)
            {
                var requestDto = new UpdateProductRequestDto()
                {
                    Id = model.Id,
                    ProductCode = model.ProductCode,
                    ProductName = model.ProductName,
                    Qty = model.Qty,
                    UnitId = model.UnitId
                };

                updateProductAppService.Execute(requestDto);
            }
            var units = _productDbContext.Units.ToList();
            ViewBag.subGroupNameList = units;
            var products = _productDbContext.Products.ToList();
            ViewBag.Products = products;
            return RedirectToAction("Index");
        }
    }
}
using AbidiProducts.Core.ApplicationService.Products.AddProduct;
using AbidiProducts.Core.ApplicationService.Products.AddProduct.Dtos;
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

        public HomeController(ProductDbContext productDbContext,IProductRepository productRepo,IUnitRepository unitRepository)
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
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel model, [FromServices] IAddProductAppService addProductAppService)
        {
            var requestDto = new AddProductRequestDto()
            {
                ProductCode = model.ProductCode,
                ProductName = model.ProductName,
                Qty = model.Qty,
                UnitId = model.UnitId
            };

            addProductAppService.Execute(requestDto);
            return Redirect("Index");
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            return Redirect("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
            return Redirect("Index");
        }
    }
}
using AbidiProducts.Core.ApplicationService.Units.AddUnit;
using AbidiProducts.Core.ApplicationService.Units.AddUnit.Dtos;
using AbidiProducts.Core.ApplicationService.Units.UpdateUnit;
using AbidiProducts.Core.ApplicationService.Units.UpdateUnit.Dtos;
using AbidiProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace AbidiProducts.Controllers
{
    public class UnitController : Controller
    {
        private readonly ProductDbContext productDbContext;
        private readonly IUnitRepository _unitRepo;

        public UnitController(ProductDbContext productDbContext,IUnitRepository unitRepo)
        {
            this.productDbContext = productDbContext;
            this._unitRepo = unitRepo;
        }
        public IActionResult Index()
        {
            var units = productDbContext.Units.ToList();
            ViewBag.unitList = units;
            return View();
        }
        public IActionResult DeleteUnit(int id)
        {
            _unitRepo.DeleteUnit(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateEditUnit(int? id) 
        {
            var dto = new UnitViewModel
            {
                Id = id ?? -1
            };

            if (id !=null)
            {
                var units = productDbContext.Units.Where(c=>c.Id == id).Select(c=>c).First();
                dto = new UnitViewModel
                {
                    Id = units.Id,
                    UnitName = units.UnitName
                };
            }
           
            return PartialView("_UnitPartialView", dto);
        }

        [HttpPost]
        public IActionResult CreateEditUnit(UnitViewModel model, [FromServices] IAddUnitAppService addUnitAppService, [FromServices] IUpdateUnitAppService updateUnitAppService)
        {
            if (model.Id == -1)
            {
                var requestDto = new AddUnitRequestDto()
                {
                    UnitName = model.UnitName
                };

                addUnitAppService.Execute(requestDto);
            }
            else if(model.Id > 0)
            {
                var requestDto = new UpdateUnitRequestDto()
                {
                    Id=model.Id,
                    UnitName = model.UnitName
                };

                updateUnitAppService.Execute(requestDto);
            }
            var units = productDbContext.Units.ToList();
            ViewBag.unitList = units;
            return RedirectToAction("Index");
        }
    }
}

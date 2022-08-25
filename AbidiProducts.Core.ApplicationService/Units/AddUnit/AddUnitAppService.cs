using AbidiProducts.Core.ApplicationService.Units.AddUnit.Dtos;
using AbidiProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbidiProducts.Core.ApplicationService.Units.AddUnit
{
    public class AddUnitAppService:IAddUnitAppService
    {
        private readonly IUnitRepository unitRepository;

        public AddUnitAppService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        public void Execute(AddUnitRequestDto requestDto)
        {
            unitRepository.AddUnit(requestDto.UnitName);
        }
    }
}

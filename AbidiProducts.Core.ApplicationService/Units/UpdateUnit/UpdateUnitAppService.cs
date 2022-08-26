using AbidiProducts.Core.ApplicationService.Units.UpdateUnit.Dtos;
using AbidiProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbidiProducts.Core.ApplicationService.Units.UpdateUnit
{
    public class UpdateUnitAppService : IUpdateUnitAppService
    {
        private readonly IUnitRepository unitRepository;

        public UpdateUnitAppService(IUnitRepository unitRepository)
        {
            this.unitRepository = unitRepository;
        }
        public void Execute(UpdateUnitRequestDto updateUnitRequestDto)
        {
            unitRepository.UpdateUnit(updateUnitRequestDto.Id,updateUnitRequestDto.UnitName);
        }
    }
}

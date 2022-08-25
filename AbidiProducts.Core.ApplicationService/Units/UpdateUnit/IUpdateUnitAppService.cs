using AbidiProducts.Core.ApplicationService.Units.UpdateUnit.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbidiProducts.Core.ApplicationService.Units.UpdateUnit
{
    public interface IUpdateUnitAppService
    {
        void Execute(UpdateUnitRequestDto updateUnitRequestDto);
    }
}

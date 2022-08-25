using AbidiProducts.Core.ApplicationService.Units.AddUnit.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbidiProducts.Core.ApplicationService.Units.AddUnit
{
    public interface IAddUnitAppService
    {
        void Execute(AddUnitRequestDto requestDto);
    }
}

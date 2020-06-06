using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Modules.Common.Models.Region;

namespace Api.Modules.Common.Services
{
    public interface IRegionService
    {
        Task<List<RegionModel>> GetAllRegionAsync();
    }
}

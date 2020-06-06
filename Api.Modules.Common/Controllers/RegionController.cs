using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Data.Postgre.Dao.Interfaces;
using Api.Modules.Common.Models.Region;
using Api.Modules.Common.Services;
using AutoMapper;
using Base.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Common.Controllers
{
    [ApiController]
    [Route("api/regions")]
    public class RegionController : BaseRestController
    {
        private readonly IRegionService regionService;

        public RegionController(
            IRegionService regionService
            )
        {
            this.regionService = regionService;
        }
        public async Task<List<RegionModel>> GetAllRegion()
        {
            var result = await regionService.GetAllRegionAsync();
            return result;
        }
    }
}

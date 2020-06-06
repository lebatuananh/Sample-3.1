using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Data.Postgre.Dao.Interfaces;
using Api.Modules.Common.Models.Region;
using AutoMapper;

namespace Api.Modules.Common.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionDao regionDao;

        public RegionService(
            IRegionDao regionDao
            )
        {
            this.regionDao = regionDao;
        }

        public async Task<List<RegionModel>> GetAllRegionAsync()
        {
            var dtoes = await regionDao.FilterAsync();
            var models = dtoes
                .Select(dto => Mapper.Map<RegionModel>(dto))
                .ToList();
            return models;
        }
    }
}

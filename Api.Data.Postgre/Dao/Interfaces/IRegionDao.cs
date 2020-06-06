using System;
using System.Collections.Generic;
using System.Text;
using Api.Data.Postgre.Dto;
using Base.Data.Postgre.Dao.Interfaces;

namespace Api.Data.Postgre.Dao.Interfaces
{
    public interface IRegionDao : IPostgreDao<RegionDto>
    {
    }
}

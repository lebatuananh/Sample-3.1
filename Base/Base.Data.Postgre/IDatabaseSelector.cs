using System;
using System.Collections.Generic;
using System.Text;
using Base.Data.Postgre.Dto;
using Microsoft.EntityFrameworkCore;

namespace Base.Data.Postgre
{
    public interface IDatabaseSelector
    {
        DbContext GetDbContext<TDto>() where TDto : BaseDto;
    }
}

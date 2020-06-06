using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Base.Data.Postgre.Dto;

namespace Api.Data.Postgre.Dto
{
    [Table("city")]
    public class ProvinceDto : BaseDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public int Order { get; set; }
    }
}

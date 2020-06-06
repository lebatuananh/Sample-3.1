using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Base.Data.Postgre.Dto;

namespace Api.Data.Postgre.Dto
{
    [Table("district")]
    public class DistrictDto : BaseDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int Priority { get; set; }
    }
}

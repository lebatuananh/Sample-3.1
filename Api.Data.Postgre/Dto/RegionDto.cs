using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Base.Data.Postgre.Dto;

namespace Api.Data.Postgre.Dto
{
    [Table("region")]
    public class RegionDto : BaseDto
    {
        [Key]
        //[Column("id")]
        public int Id { get; set; }
        //[Column("name")]
        public string Name { get; set; }
        //[Column("namealias")]
        public string Alias { get; set; }
        //[Column("nameenglish")]
        public string EnglishName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HSPA_WebApi.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string Name { get; set; }

        [Required]
        public string  Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;

namespace WepApi.Services
{
    public class PointOfInterestDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}

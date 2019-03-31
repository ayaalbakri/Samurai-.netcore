using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Models
{
    public class PointOfInterest : BaseDto
    {
        #region "PointOfInterest Model"
        public string Name { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        #endregion
    }
}

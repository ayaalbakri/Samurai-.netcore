using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Models
{
    public class City : BaseDto
    {
        #region "City Model"
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointsOfInterest { get; set; }
        public ICollection<PointOfInterest> PointsOfInterest { get; set; }
         = new List<PointOfInterest>();
    }
    #endregion
}

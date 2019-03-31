using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;

namespace WepApi.Domain_Models.CityRepository
{
    public interface ICityRepository : IRepository<City>
    {
        int getID(City entity);
         IEnumerable<PointOfInterest> GetPointsOfInterests(int cityID);
         PointOfInterest GetPointsOfInterest(int cityID, int id);
    }
   
}

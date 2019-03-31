using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WepApi.Models;
using WepApi.Services;


namespace WepApi.Domain_Models.CityRepository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private IUnitOfWork _unitOfWork;
        public CityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int getID(City entity)
        {
            return entity.Id;
        }
        public IEnumerable<PointOfInterest> GetPointsOfInterests(int cityID)
        {
            return _unitOfWork.Context.Set<PointOfInterest>().Where(p => p.CityId == cityID).ToList();
        }
        public PointOfInterest GetPointsOfInterest(int cityID,int id)
        {
            IEnumerable<PointOfInterest> PointOfInterests = GetPointsOfInterests(cityID);
            return PointOfInterests.SingleOrDefault(e => e.Id == id);
        }
    }
}

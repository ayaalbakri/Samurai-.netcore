using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Domain_Models.CityRepository;
using WepApi.Models;
using WepApi.Services;

namespace WepApi.Domain_Models.PointOfInterestRepository
{
    public class PointOfInterestRepository : Repository<PointOfInterest>, IPointOfInterestRepository
    {
        private IUnitOfWork _unitOfWork;
        public PointOfInterestRepository(IUnitOfWork unitOfWork, ICityRepository cityRepository):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override void Create(PointOfInterest entity,int cityId)
        {
            entity.CityId = cityId;
            _unitOfWork.Context.Set<PointOfInterest>().Add(entity);
            _unitOfWork.Commit();
        }

    }
}

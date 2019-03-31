using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepApi.Domain_Models.CityRepository;
using WepApi.Domain_Models.PointOfInterestRepository;
using WepApi.Models;
using WepApi.Services;

namespace WepApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class PointOfInterestController : Controller
    {
        private IPointOfInterestRepository _pointOfInterest;
        private ICityRepository _cityRepository;
        private IMapper _mapper;

        public PointOfInterestController(IPointOfInterestRepository pointOfInterest , ICityRepository cityRepository, IMapper mapper)
        {
            _pointOfInterest = pointOfInterest;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        #region
        [ValidateCityExists]
        [HttpGet("{cityId}/PointOfInterest")]
        
        public IActionResult GetPointsOfInterest(int cityId)
        {
           IEnumerable<PointOfInterest> PointsOfInterests = _cityRepository.GetPointsOfInterests(cityId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(PointsOfInterests));
        }
        #endregion

        #region "// GET: api/PointOfInterest/5"
        [ValidateCityExists]
        [HttpGet("{cityId}/pointsofinterest/{PointId}")]
        public IActionResult GetPointOfInterest(int cityId, int PointId)
        {
          
            return Ok(_cityRepository.GetPointsOfInterest(cityId, PointId));
        }
        #endregion

        #region "HttpPost{cityId}/pointsofinterest""
        [ValidateCityExists]
        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,[FromBody] PointOfInterest pointOfInterest)
        {
            _pointOfInterest.Create( pointOfInterest, cityId);
            return Ok();
        }
        #endregion

        #region "HttpDelete("pointsofinterest")"
        [ValidateModel]
        [HttpDelete("pointsofinterest")]
        public IActionResult DeletePointOfInterest([FromBody] PointOfInterestDto pointOfInterestDto)
        {
            PointOfInterest pointOfInterest = _mapper.Map<PointOfInterest>(pointOfInterestDto);
            _pointOfInterest.Delete(pointOfInterest.Id);
            return Ok();

        }
        #endregion
    }
}

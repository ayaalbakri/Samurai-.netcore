using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WepApi.Domain_Models.CityRepository;
using WepApi.Models;
using WepApi.Services;

namespace WepApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class CityController : Controller
    {
        private ICityRepository _city;
        private IMapper _mapper;
        public CityController(ICityRepository city, IMapper mapper)
        {
            _city = city;
            _mapper = mapper;
        }
        /// <summary>
        /// Get all cities
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize(Policy = "AllowGet")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var xxx = User.Claims;
            IEnumerable<City> cities = _city.GetAll();
            var allCities = _mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(allCities);
        }

        [HttpGet("{id}")]
        [ValidateCityExists]
        public IActionResult Get(int id)
        {
            City city = _city.GetById(id);
            return Ok(_mapper.Map<CityDto>(city));
        }
        [HttpPost]
        [ValidateModel]
        public void Post([FromBody] CityDto city)
        {
            City result = _mapper.Map<City>(city);
            _city.Create(result);
        }
        [HttpDelete("{id}")]
        [ValidateCityExists]
        public void deleteCity(int id)
        {
            _city.Delete(id);
        }
        [HttpPut]
        [ValidateCityExists]
        [ValidateModel]
        [SampleActionFilter]
        public void updateCity([FromBody] CityDto citytdo)
        {
            City city = _mapper.Map<City>(citytdo);
            _city.Update(city);
        }

    }
}
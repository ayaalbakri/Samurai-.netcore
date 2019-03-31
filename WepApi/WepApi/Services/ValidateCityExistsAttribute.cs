using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Domain_Models.CityRepository;

namespace WepApi.Services
{
    public class ValidateCityExistsAttribute : TypeFilterAttribute
    {
          public ValidateCityExistsAttribute():base(typeof
    (ValidateCityExistsFilterImpl))
  {
  }
  private class ValidateCityExistsFilterImpl : IAsyncActionFilter
  {
   // private readonly IAuthorRepository _authorRepository;
            private ICityRepository _cityRepository;

            public ValidateCityExistsFilterImpl(ICityRepository cityRepository)
    {
      _cityRepository= cityRepository;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context,
      ActionExecutionDelegate next)
    {
                if (context.ActionArguments.ContainsKey("citytdo"))
                {
                    var body = context.ActionArguments["citytdo"] as CityDto;
                    if (body.Id == 0)
                    {
                        context.Result = new NotFoundObjectResult("ID can't found");
                        return;
                    }
                    if ((_cityRepository.GetAll()).All(a => a.Id != body.Id))
                    {
                        context.Result = new NotFoundObjectResult("value can't found");
                        return;
                    }
                }
      if (context.ActionArguments.ContainsKey("id"))
      {
        var id = context.ActionArguments["id"] as int?;
        if (id.HasValue)
        {
          if (( _cityRepository.GetAll()).All(a => a.Id != id.Value))
          {
             context.Result = new NotFoundObjectResult("value can't found");
             return;
          }
        }
      }
                if (context.ActionArguments.ContainsKey("cityId"))
                {
                    var cityId = context.ActionArguments["cityId"] as int?;
                    if (cityId.HasValue)
                    {
                        if ((_cityRepository.GetAll()).All(a => a.Id != cityId.Value))
                        {
                            context.Result = new NotFoundObjectResult("value can't found");
                            return;
                        }
                    }
                }
                await next();
    }
  }
    }
}

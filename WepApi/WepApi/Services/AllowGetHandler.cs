using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;

namespace WepApi.Services
{
    public class AllowGetHandler : AuthorizationHandler<AllowGet>
    {
        private IUnitOfWork _unitOfWork;

        public AllowGetHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowGet requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Email"))
            {
                //TODO: Use the following if targeting a version of
                //.NET Framework older than 4.6:
                //      return Task.FromResult(0);
                return Task.CompletedTask;
            }

            //var dateOfBirth = Convert.ToDateTime(
            // context.User.Claims.FindFirst(c => c.Type == "Email").Value;
            var email = context.User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            //return _unitOfWork.Context.Set<PointOfInterest>().Where(p => p.CityId == cityID).ToList();
            int userId = _unitOfWork.Context.Set<User>().FirstOrDefault(e => e.Email == email).Id;
            if (_unitOfWork.Context.Set<UserPermision>().Any(c => c.PermisionId == 1 && c.UserId == userId))
            {
                context.Succeed(requirement);
            };
            //int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
            //if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
            //{
            //    calculatedAge--;
            //}

            //if (calculatedAge >= requirement.MinimumAge)
            //{
            //    context.Succeed(requirement);
            //}

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }
}


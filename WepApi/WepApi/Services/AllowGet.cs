using Microsoft.AspNetCore.Authorization;

namespace WepApi.Services
{
    public class AllowGet : IAuthorizationRequirement
    {
        public string Email { get; private set; }

        public AllowGet(string email)
        {
            Email = email;
        }

    }
}

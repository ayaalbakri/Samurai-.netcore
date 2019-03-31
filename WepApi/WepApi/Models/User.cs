using System.Collections.Generic;
using WepApi.Services;

namespace WepApi.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<UserPermision> permision { get; set; }


    }
}

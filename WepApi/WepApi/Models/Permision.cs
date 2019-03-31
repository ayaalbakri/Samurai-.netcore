using System.Collections.Generic;
using WepApi.Services;

namespace WepApi.Models
{
    public class Permision : BaseEntity
    {
        public string API { get; set; }
        public List<UserPermision> user { get; set; }
    }
}

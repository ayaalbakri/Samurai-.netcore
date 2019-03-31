using WepApi.Services;

namespace WepApi.Models
{
    public class UserPermision : BaseEntity
    {
        public int PermisionId { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public Permision permision { get; set; }

    }
}

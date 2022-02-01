using Core.Entities.Abstract;

namespace Entities.DTOs.User {
    public class UserForLoginDto : IDto {
        public String EmailAdress { get; set; }
        public String Password { get; set; }
    }
}
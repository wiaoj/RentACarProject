using Core.Entities.Abstract;

namespace Entities.DTOs.User {
    public class UserForRegisterDto : IDto {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String EmailAdress { get; set; }
        public String Password { get; set; }
    }
}
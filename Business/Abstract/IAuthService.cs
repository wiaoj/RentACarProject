using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.DTOs.User;

namespace Business.Abstract {
    public interface IAuthService {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, String password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(String emailAdress);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}

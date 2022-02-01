using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Error;
using Core.Utilities.Result.Concrete.Success;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs.User;

namespace Business.Concrete {
    public class AuthManager : IAuthService {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper) {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user) {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu" /*Messages.AccessTokenCreated)*/);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto) {
            var user = CheckUserIfEmailAdress(userForLoginDto.EmailAdress);
            IResult? result = BusinessRules.Run(user,
                VerifyPasswordHash(userForLoginDto.Password, user.Data.PasswordHash,
                user.Data.PasswordSalt));
            //if (result != null) {
            //    return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            //}
            //if (result != null) {
            //    return new ErrorDataResult<User>("Parola Hatası");
            //}
            //null ise giriş yapılacak
            return result is null ?
                new SuccessDataResult<User>(user.Data,"Giriş başarılı" /*Messages.SuccessfulLogin*/) :
                new ErrorDataResult<User>(result.Message);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, String password) {
            HashingHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new() {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                EmailAdress = userForRegisterDto.EmailAdress,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt başarıyla tamamlandı");
        }

        public IResult UserExists(String emailAdress) {
            return BusinessRules.Run(CheckUserIfEmailAdress(emailAdress)) is null ?
                new SuccessResult("Kullanıcı mevcut"/*Messages.UserAlreadyExists*/) :
                new ErrorResult();
        }


        private IDataResult<User> CheckUserIfEmailAdress(String emailAdress) {
            //mail adresi yoksa null oluyor
            var userToCheck = _userService.GetByMail(emailAdress).Data;
            return userToCheck is not null ?
                new SuccessDataResult<User>(userToCheck) :
                new ErrorDataResult<User>("Kullanıcı bulunamadı"/*Messages.UserNotFound)*/);
        }

        private IResult VerifyPasswordHash(String password, byte[] passwordHash, byte[] passwordSalt) {
            return HashingHelper.VerifyPasswordHash(password,
                passwordHash, passwordSalt) ?
                new SuccessResult() :
                new ErrorResult("Parolanız yanlış"/*Messages.PasswordError*/);
        }

    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Extensions.Claims {
    public static class ClaimExtensions {
        //ICollection<Claim> add paramaters
        public static void AddEmail(this ICollection<Claim> claims, String emailAdress) {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, emailAdress));
        }

        public static void AddName(this ICollection<Claim> claims, String name) {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, String nameIdentifier) {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, String[] roles) {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
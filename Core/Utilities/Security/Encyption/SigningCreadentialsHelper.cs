using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyption {
    public class SigningCreadentialsHelper {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) {
            return new SigningCredentials(
                key: securityKey, 
                algorithm: 
                SecurityAlgorithms.HmacSha512Signature
                );
        }
    }
}
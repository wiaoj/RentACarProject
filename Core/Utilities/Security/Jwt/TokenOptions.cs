namespace Core.Utilities.Security.Jwt {
    public class TokenOptions {
        public String? Audience { get; set; }
        public String? Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public String? SecurityKey { get; set; }
    }
}
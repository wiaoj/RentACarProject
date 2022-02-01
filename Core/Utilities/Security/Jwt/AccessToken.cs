namespace Core.Utilities.Security.Jwt {
    public class AccessToken {
        public String? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
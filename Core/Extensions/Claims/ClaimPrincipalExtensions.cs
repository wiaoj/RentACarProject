using System.Security.Claims;

namespace Core.Extensions.Claims {
    public static class ClaimPrincipalExtensions {
        public static List<String> Claims(this ClaimsPrincipal claimsPrincipal, String claimType) {
            return claimsPrincipal.FindAll(claimType).Select(c => c.Value).ToList();
        }

        public static List<String> ClaimRoles(this ClaimsPrincipal claimsPrincipal) {
            return claimsPrincipal.Claims(ClaimTypes.Role);
        }
    }
}
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing {
    public class HashingHelper {
        public static void CreatePasswordHash(String password, out byte[] passwordHash, out byte[] passwordSalt) {
            using HMACSHA512 hmac = new();
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            passwordSalt = hmac.Key;
        }

        public static bool VerifyPasswordHash(String password, byte[] passwordHash, byte[] passwordSalt) {
            using HMACSHA512 hmac = new(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++) {
                if (computedHash[i] != passwordHash[i]) {
                    return false;
                }
            }
            return true;
        }
    }
}
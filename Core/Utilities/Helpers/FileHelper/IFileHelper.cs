using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper {
    public interface IFileHelper {
        public String? Upload(IFormFile file, String root);
        public void Delete(String filePath);
        public String? Update(IFormFile file, String filePath, String root);
    }
}
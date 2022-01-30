using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation {
    public static class ValidationTool {
        public static void Validate(IValidator validator, object entity) {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
                throw new ValidationException(result.Errors); 
                //19 dilde desteği varmış tarayıcı diline göre mesajı gösteriyor
                //özel oluşturduğumuz metotlar hariç tabii onları kendimiz veriyoruz
        }
    }
}

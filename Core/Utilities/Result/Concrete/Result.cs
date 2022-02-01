using Core.Utilities.Result.Abstract;

namespace Core.Utilities.Result.Concrete {
    public class Result : IResult {
        public bool Success { get; }
        public String Message { get; }

        public Result(bool success, String message) : this(success) => Message = message;
        public Result(bool success) => Success = success;
    }
}

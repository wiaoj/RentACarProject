namespace Core.Utilities.Result.Concrete.Error {
    public class ErrorResult : Result {
        public ErrorResult(String message) : base(false, message) { }
        public ErrorResult() : base(false) { }
    }
}

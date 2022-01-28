namespace Core.Utilities.Result.Concrete.Success {
    public class SuccessResult : Result {
        public SuccessResult(String message) : base(true, message) { }
        public SuccessResult() : base(true) { }
    }
}

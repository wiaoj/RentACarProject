namespace Core.Utilities.Result.Concrete.Success {
    public class SuccessDataResult<Type> : DataResult<Type> {
        public SuccessDataResult(Type? data, String message) : base(data, true, message) { }
        public SuccessDataResult(Type? data) : base(data, true) { }
        public SuccessDataResult(String message) : base(default, true, message) { }
        public SuccessDataResult() : base(default,true) { }
    }
}

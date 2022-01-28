namespace Core.Utilities.Result.Concrete.Error {
    public class ErrorDataResult<Type> : DataResult<Type> {
        public ErrorDataResult(Type data, String message) : base(data, false, message) { }
        public ErrorDataResult(Type data) : base(data, false) { }
        public ErrorDataResult(String message) : base(default, false, message) { }
        public ErrorDataResult() : base(default, false) { }
    }
}

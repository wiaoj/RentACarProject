namespace Core.Utilities.Result.Abstract {
    public interface IResult {
        public bool Success { get; }
        public String? Message { get; }
    }
}

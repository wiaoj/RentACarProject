namespace Core.Utilities.Result.Abstract {
    public interface IDataResult<Type> : IResult {
        Type Data { get; }
    }
}
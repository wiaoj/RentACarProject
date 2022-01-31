using Core.Utilities.Result.Abstract;

namespace Core.Utilities.Result.Concrete {
    public class DataResult<Type> : Result, IDataResult<Type> {
        public Type Data { get; }
        public DataResult(Type data, bool success, String message) :base(success, message) => Data = data;
        public DataResult(Type data, bool success) : base(success) => Data = data;
    }
}
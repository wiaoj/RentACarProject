using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;

namespace Core.Utilities.Payment {
    public class Payment {
        public static IResult Pay(CreditCard creditCard) {
            return new SuccessResult("The payment has been made successfully.");
        }
    }
}
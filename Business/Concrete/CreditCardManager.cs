using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;

namespace Business.Concrete {
    public class CreditCardManager : ICreditCardService {
        private readonly ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal) {
            _creditCardDal = creditCardDal;
        }

        [ValidationAspect(typeof(CreditCardValidation))]
        public IResult Add(CreditCard creditCard) {
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        public IResult Delete(CreditCard creditCard) {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        //public IDataResult<List<CreditCard>> GetAll() {
        //    return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        //}

        public IDataResult<CreditCard> GetByCustomerId(int customerId) {
            //birden fazla kredi kartı varsa onun için entityFramework içinde metotd yazılmalı
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.CustomerId.Equals(customerId)));
        }

        public IResult Payment(CreditCard creditCard, int carId) {
            //Core.Utilities.Payment.Payment.Pay(creditCard);
            //return new SuccessResult("Ödeme başarılı");
            return Core.Utilities.Payment.Payment.Pay(creditCard);
        }

        [ValidationAspect(typeof(CreditCardValidation))]
        public IResult Update(CreditCard creditCard) {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }
    }
}
using Business.Abstract;
using Business.Aspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public IDataResult<List<CreditCard>> GetAll() {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<CreditCard> GetById(int id) {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c=>c.Id.Equals(id)));
        }

        public IResult Payment(CreditCard creditCard) {
            return new SuccessResult("Ödeme başarıyla yapıldı");
        }

        [ValidationAspect(typeof(CreditCardValidation))]
        public IResult Update(CreditCard creditCard) {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }
    }
}
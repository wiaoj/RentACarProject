using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    public class CustomerManager : ICustomerService {
        private readonly ICustomerDal _customerService;
        public CustomerManager(ICustomerDal customerDal) {
            _customerService = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer) {
            _customerService.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }
        
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Delete(Customer customer) {
            _customerService.Delete(customer);
            return new SuccessResult(Messages.CustomerRemoved);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<Customer?> GetById(int customerId) {
            return new SuccessDataResult<Customer?>(_customerService.Get(c => c.UserId.Equals(customerId)));
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IDataResult<List<Customer>> GetAll() {
            return new SuccessDataResult<List<Customer>>();
        }
        
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer) {
            _customerService.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
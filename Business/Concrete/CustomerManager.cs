using Business.Abstract;
using Business.Aspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete {
    //[SecuredOperation("admin,customer.admin")]
    public class CustomerManager : ICustomerService {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal) => _customerDal = customerDal;

        [SecuredOperation("admin,customer.admin,customer.add")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer) {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [SecuredOperation("admin,customer.admin,customer.delete")]
        public IResult Delete(Customer customer) {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerRemoved);
        }

        public IDataResult<List<Customer>> GetAll() {
            return new SuccessDataResult<List<Customer>>();
        }

        public IDataResult<Customer> GetById(int customerId) {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id.Equals(customerId)));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails() {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        [SecuredOperation("admin,customer.admin,customer.update")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer) {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
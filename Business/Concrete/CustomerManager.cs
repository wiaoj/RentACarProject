﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete {
    internal class CustomerManager : ICustomerService {
        private readonly ICustomerDal _customerService;
        public CustomerManager(ICustomerDal customerDal) {
            _customerService = customerDal;
        }

        public IResult Add(Customer customer) {
            _customerService.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer) {
            _customerService.Delete(customer);
            return new SuccessResult(Messages.CustomerRemoved);
        }

        public IDataResult<List<Customer>> GetAll() {
            return new SuccessDataResult<List<Customer>>();
        }

        public IDataResult<Customer?> GetById(int customerId) {
            return new SuccessDataResult<Customer?>(_customerService.Get(c => c.UserId.Equals(customerId)));
        }

        public IResult Update(Customer customer) {
            _customerService.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
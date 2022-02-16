using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Core.Entities.Concrete;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase {
        private readonly ICreditCardService _creditCardService;
        public CreditCardsController(ICreditCardService creditCardService) => _creditCardService = creditCardService;

        [HttpPost]
        public IActionResult Add(CreditCard creditCard) {
            var result = _creditCardService.Add(creditCard);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(CreditCard creditCard) {
            var result = _creditCardService.Update(creditCard);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(CreditCard creditCard) {
            var result = _creditCardService.Delete(creditCard);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        //[HttpGet]
        //public IActionResult GetAll() {
        //    Thread.Sleep(1000);
        //    var result = _creditCardService.GetAll();
        //    return result.Success ? Ok(result) : BadRequest(result);
        //}

        [HttpPost("pay")]
        public IActionResult GetPayment(CreditCard creditCard, int carId) {
            var result = _creditCardService.Payment(creditCard, carId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int id) {
            var result = _creditCardService.GetByCustomerId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
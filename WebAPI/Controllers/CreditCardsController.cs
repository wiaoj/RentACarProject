using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

        [HttpGet]
        public IActionResult GetAll() {
            Thread.Sleep(1000);
            var result = _creditCardService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("pay")]
        public IActionResult GetPayment(CreditCard creditCard) {
            var result = _creditCardService.Payment(creditCard);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _creditCardService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase {
        readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Add(Customer customer) {
            var result = _customerService.Add(customer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Customer customer) { 
            var result = _customerService.Update(customer);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Customer customer) { 
            var result = _customerService.Delete(customer);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id) { 
            var result = _customerService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll() { 
            var result = _customerService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase {
        private readonly IRentalService _rentalService;
        public RentalsController(IRentalService rentalService) => _rentalService = rentalService;

        [HttpPost]
        public IActionResult Add(Rental rental) {
            var result = _rentalService.Add(rental);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Rental rental) {
            var result = _rentalService.Update(rental);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Rental rental) {
            var result = _rentalService.Delete(rental);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll() {
            Thread.Sleep(3000);
            var result = _rentalService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _rentalService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("rentaldetails")]
        public IActionResult GetRentalDetails() {
            var result = _rentalService.GetRentalDetails();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("checkifcarisavailable")]
        public IActionResult CheckIfCarIsAvailable(int carId, DateTime rentDate, DateTime returnDate) {
            var result = _rentalService.CheckIfCarIsAvailable(carId, rentDate, returnDate);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
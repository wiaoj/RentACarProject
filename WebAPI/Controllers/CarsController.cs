using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase {
        readonly ICarService _carService;
        public CarsController(ICarService carService) => _carService = carService;

        [HttpPost]//[HttpPost("add")]
        public IActionResult Add(Car car) {
            var result = _carService.Add(car);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]//[HttpPost("update")]
        public IActionResult Update(Car car) {
            var result = _carService.Update(car);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]//[HttpPost("delete")]
        public IActionResult Delete(Car car) {
            var result = _carService.Delete(car);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]//[HttpGet("getall")]
        public IActionResult GetAll() {
            Thread.Sleep(3000);
            var result = _carService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _carService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetCarsDetailsByBrandId(int id) {
            var result = _carService.GetCarsDetailsByBrandId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetCarsDetailsByColorId(int id) {
            var result = _carService.GetCarsDetailsByColorId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcarsdetails")]
        public IActionResult GetCarsDetails() {
            var result = _carService.GetCarsDetails();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getcardetailsbyid")]
        public IActionResult GetCarDetailsById(int id) {
            var result = _carService.GetCarDetailsById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase {
        private readonly ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService) => _carImageService = carImageService;

        [HttpPost]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage) {
            var result = _carImageService.Add(file, carImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(CarImage carImage) {
            var carDeleteImage = _carImageService.GetById(carImage.Id).Data;
            var result = _carImageService.Delete(carDeleteImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromForm] CarImage carImage) {
            var result = _carImageService.Update(file, carImage);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll() {
            var result = _carImageService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _carImageService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        //[Route("getimagesbycarid/{carId}")]
        public IActionResult GetImagesByCarId(int carId) {
            var result = _carImageService.GetImagesByCarId(carId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService) => _brandService = brandService;

        [HttpPost("add")]//[HttpGet("add")]
        public IActionResult Add(Brand brand) {
            var result = _brandService.Add(brand);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]//[HttpGet("update")]
        public IActionResult Update(Brand brand) {
            var result = _brandService.Update(brand);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]//[HttpGet("delete")]
        public IActionResult Delete(Brand brand) {
            var result = _brandService.Delete(brand);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]//[HttpGet("getall")]
        public IActionResult GetAll() {
            Thread.Sleep(1000);
            var result = _brandService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _brandService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
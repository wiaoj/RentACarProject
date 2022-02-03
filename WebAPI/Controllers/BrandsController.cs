using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase {
        readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService) => _brandService = brandService;

        [HttpPost]//[HttpGet("add")]
        public IActionResult Add(Brand brand) {
            var result = _brandService.Add(brand);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]//[HttpGet("update")]
        public IActionResult Update(Brand brand) {
            var result = _brandService.Update(brand);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]//[HttpGet("delete")]
        public IActionResult Delete(Brand brand) {
            var result = _brandService.Delete(brand);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]//[HttpGet("getall")]
        public IActionResult GetAll() {
            Thread.Sleep(3000);
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
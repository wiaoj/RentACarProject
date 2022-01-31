using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase {
        readonly IColorService _colorService;
        public ColorsController(IColorService colorService) => _colorService = colorService;

        [HttpPost]
        public IActionResult Add(Color color) {
            var result = _colorService.Add(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Color color) {
            var result = _colorService.Update(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Color color) {
            var result = _colorService.Delete(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) { 
            var result = _colorService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll() {
            var result = _colorService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase {
        private readonly IColorService _colorService;
        public ColorsController(IColorService colorService) => _colorService = colorService;

           [HttpPost("add")]
        public IActionResult Add(Color color) {
            var result = _colorService.Add(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Color color) {
            var result = _colorService.Update(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color) {
            var result = _colorService.Delete(color);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll() {
            Thread.Sleep(1000);
            var result = _colorService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) { 
            var result = _colorService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        
    }
}
﻿using Business.Abstract;
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

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _carService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]//[HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _carService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("brandid")]
        public IActionResult GetByBrandId(int brandId) {
            var result = _carService.GetCarsByBrandId(brandId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("colorid")]
        public IActionResult GetByColorId(int colorId) {
            var result = _carService.GetCarsByColorId(colorId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("cardetails")]
        public IActionResult GetCarDetails() {
            var result = _carService.GetCarDetails();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
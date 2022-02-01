using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase {
        IOperationClaimService _operationClaimService;
        public OperationClaimsController(IOperationClaimService operationClaimService) => _operationClaimService = operationClaimService;

        [HttpPost] //[HttpPost("add")]
        public IActionResult Add(OperationClaim operationClaim) {
            var result = _operationClaimService.Add(operationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete] //[HttpPost("delete")]
        public IActionResult Delete(OperationClaim operationClaim) {
            var result = _operationClaimService.Delete(operationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut] //[HttpPost("update")]
        public IActionResult Update(OperationClaim operationClaim) {
            var result = _operationClaimService.Update(operationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _operationClaimService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _operationClaimService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase {
        private readonly IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService) => _userOperationClaimService = userOperationClaimService;

        [HttpPost("add")]//[HttpPost("add")]
        public IActionResult Add(UserOperationClaim userOperationClaim) {
            var result = _userOperationClaimService.Add(userOperationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update")]//[HttpPost("update")]
        public IActionResult Update(UserOperationClaim userOperationClaim) {
            var result = _userOperationClaimService.Update(userOperationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("delete")]//[HttpPost("delete")]
        public IActionResult Delete(UserOperationClaim userOperationClaim) {
            var result = _userOperationClaimService.Delete(userOperationClaim);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet] //[HttpGet("getall")]
        public IActionResult GetAll() {
            var result = _userOperationClaimService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) {
            var result = _userOperationClaimService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id) {
            var result = _userOperationClaimService.GetUserOperationClaimByUserId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyoperationclaimid")]
        public IActionResult GetByOperationClaimId(int id) {
            var result = _userOperationClaimService.GetUserOperationClaimByOperationClaimId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
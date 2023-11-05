using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoFactorService.Model;

namespace TwoFactorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _2fServicesController : ControllerBase
    {
        private readonly CodeService _service;
        public _2fServicesController(CodeService service)
        {
            _service = service;
        }
        [HttpPost("generate")]
        public IActionResult GenerateCode(PhoneRequest request)
        {
            var code = _service.GenerateCode(request.Phone);
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest(new { Message = "Too many concurrent codes" });
            }
            return Ok(new { Success = true });
        }

        [HttpPost("validate")]
        public IActionResult ValidateCode(ValidateRequest request)
        {
            bool isValid = _service.ValidateCode(request.Code, request.Code);
            return Ok(new { IsValid = isValid });
        }
    }
}

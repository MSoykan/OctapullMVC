using BusinessLayer.EmailService.Abstract;
using BusinessLayer.EmailService.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OctapullAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request) {
            emailService.SendEmail(request);

            return Ok();
        }

    }
}

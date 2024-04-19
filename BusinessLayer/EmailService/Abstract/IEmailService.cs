using BusinessLayer.EmailService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.EmailService.Abstract {
    public interface IEmailService {
        void SendEmail(EmailDto request);
    }
}

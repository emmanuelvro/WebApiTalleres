using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talleres.Models;

namespace Talleres.Intefaces.Smtp
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage, List<Atachment> files);
        Task SendEmailAsync(string email, string subject, string htmlMessage);

    }
}

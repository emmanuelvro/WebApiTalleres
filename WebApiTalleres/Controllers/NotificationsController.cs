using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Talleres.Intefaces.Smtp;
using Talleres.Intefaces.UserStories;
using Talleres.Models;
using Talleres.Models.Request;

namespace WebApiTalleres.Controllers
{
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private INotificationUserStory notificationUserStory;
        private IEmailSender emailSender;
        public NotificationsController(INotificationUserStory notificationUserStory, IEmailSender emailSender)
        {
            this.notificationUserStory = notificationUserStory;
            this.emailSender = emailSender;
        }
        [HttpPost("api/alumns/confirmation")]
        public async Task<IActionResult> Confirmation([FromBody] Alumno alumno)
        {
            await this.notificationUserStory.Confirmation(alumno).ConfigureAwait();
            return Ok();
        }

        [HttpPost("api/alumns/sendConfirmation")]
        public async Task<IActionResult> SendMail(IFormFile file)
        {
            var response = $"Received file {file.FileName} with size in bytes {file.Length}";
            var atachment = new List<Atachment>();
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                atachment.Add(new Atachment
                {
                    Name = "Inscripcion_Talleres.pdf",
                    Stream = new MemoryStream(fileBytes)
                });
            }
            await this.emailSender.SendEmailAsync(file.FileName.Replace(".pdf", ""), "Confirmación de Inscripción Talleres", "", atachment).ConfigureAwait();
            return Ok(response);
        }
    }
}

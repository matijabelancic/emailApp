using emailApp_Q.Repository.Interfaces;
using emailApp_Q.Shared;
using emailApp_Q.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace emailApp_Q.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailRepo _mailRepo;
        public MailController(IMailRepo mailRepo)
        {
            _mailRepo = mailRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetMails([FromQuery] MailParameters mailParameters)
        {
            var mails = await _mailRepo.GetAll(mailParameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(mails.MetaData));

            return (mails == null) ? NotFound() : Ok(mails);
        }

        [HttpGet("{id}", Name = "MailById")]
        public async Task<IActionResult> GetMails(int id)
        {
            var mail = await _mailRepo.GetById(id);

            return (mail == null) ? NotFound() : Ok(mail);
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> CreateCompany([FromBody] Mail mail)
        {
            if (mail == null)
            {
                return BadRequest();
            }

            mail.CC = mail.CC.Contains(";") ? mail.CC.Replace(";", " ") : mail.CC;

            await _mailRepo.Create(mail);

            return CreatedAtRoute("MailById", new { id = mail.Id }, mail);
        }
    }
}

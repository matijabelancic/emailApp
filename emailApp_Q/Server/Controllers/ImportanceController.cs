using emailApp_Q.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emailApp_Q.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportanceController : ControllerBase
    {
        private readonly IImportanceRepo _importanceRepo;

        public ImportanceController(IImportanceRepo importanceRepo)
        {
            _importanceRepo = importanceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetImportancess()
        {
            var importances = await _importanceRepo.GetAll();

            return (importances == null) ? NotFound() : Ok(importances);

        }
    }
}

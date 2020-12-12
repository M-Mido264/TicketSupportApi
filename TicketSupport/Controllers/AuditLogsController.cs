using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TS.APP;

namespace TicketSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly AuditApp auditApp;

        public AuditLogsController(AuditApp auditApp)
        {
            this.auditApp = auditApp;
        }

        [HttpGet("AllLogs/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await auditApp.GetById(id);
            return Ok(value);
        }
    }
}
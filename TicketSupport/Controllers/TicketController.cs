using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TS.APP;
using TS.DAL.Models;

namespace TicketSupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketApp _ticketApp;

        public TicketController(TicketApp ticketApp)
        {
            _ticketApp = ticketApp;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ticketApp.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _ticketApp.GetById(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Ticket model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res =  await _ticketApp.Update(model);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ticket model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var res = await _ticketApp.Post(model);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
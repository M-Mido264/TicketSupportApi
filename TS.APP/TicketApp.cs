using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.BL;
using TS.DAL.Models;

namespace TS.APP
{
    public class TicketApp
    {
        private readonly TicketService _service;

        public TicketApp(TicketService service)
        {
            _service = service;
        }

        public List<Ticket> GetAll()
        {
            return _service.GetAll();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<Ticket> Post(Ticket model)
        {
            Validation(model);
            return await _service.Post(model);
        }
        public async Task<Ticket> Update(Ticket model)
        {
            Validation(model);
            return await _service.Update(model);
        }

        private void Validation(Ticket model)
        {
            if (String.IsNullOrEmpty(model.Name))
            {
                throw new Exception("Name Cannot Be Empty");
            }
        }
    }
}

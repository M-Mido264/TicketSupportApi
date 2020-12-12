using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Models;
using TS.DAL.Repositories;

namespace TS.BL
{
    public class TicketService
    {
        private readonly TicketRepository _ticketRepository;
        private readonly AuditRepository auditRepository;

        public TicketService(TicketRepository ticketRepository, AuditRepository auditRepository)
        {
            _ticketRepository = ticketRepository;
            this.auditRepository = auditRepository;
        }

        public List<Ticket> GetAll()
        {
            return _ticketRepository.GetAll().ToList();
        }

        public Task<Ticket> GetById(int id)
        {
            return _ticketRepository.GetByIdAsync(id);
        }

        public async Task<Ticket> Post(Ticket ticket)
        {
            try
            {
                var model = await _ticketRepository.AddAsync(ticket);
                await AddLogs(model, 1);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ticket> Update(Ticket ticket)
        {
            try
            {
                var exist = await _ticketRepository.GetByIdAsync(ticket.Id);
                if(exist != null)
                {
                    if(exist.Status != ticket.Status)
                    {
                        exist.LastStatusChanges = DateTime.UtcNow;
                    }
                    exist.Name = ticket.Name;
                    exist.UserId = ticket.UserId;
                    exist.Status = ticket.Status;
                    exist.Content = ticket.Content;
                }
                var model = await _ticketRepository.UpdateAsync(exist);

                await AddLogs(model, 2);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task AddLogs(Ticket ticket, int type)
        {
            // where type equal to 1 means that add operation and 2 means update
            var model = new AuditLog
            {
                Action = type == 1 ? "Added" : "Updated",
                DateTime = DateTime.UtcNow,
                TicketId = ticket.Id,
                UserId = ticket.UserId
            };
            await auditRepository.AddAsync(model);            
        }
    }
}

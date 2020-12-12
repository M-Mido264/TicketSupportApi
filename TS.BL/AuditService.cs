using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Models;
using TS.DAL.Repositories;

namespace TS.BL
{
    public class AuditService
    {
        private readonly AuditRepository auditRepository;

        public AuditService(AuditRepository auditRepository)
        {
            this.auditRepository = auditRepository;
        }

        public Task<List<AuditLog>> GetById(int id)
        {
            return auditRepository.GetByIdAsync(id);
        }
    }
}

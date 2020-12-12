using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.BL;
using TS.DAL.Models;

namespace TS.APP
{
    public class AuditApp
    {
        private readonly AuditService auditService;

        public AuditApp(AuditService auditService)
        {
            this.auditService = auditService;
        }

        public async Task<List<AuditLog>> GetById(int id)
        {
            return await auditService.GetById(id);
        }
    }
}

using ExamPre3.Core.Models;
using ExamPre3.Core.Repository.Interfaces;
using ExamPre3.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre3.Data.Repository.Implementations
{
    public class ServiceRepository : GenericRepository<Services>, IServiceRepository
    {
        public ServiceRepository(AppDbContext appDb) : base(appDb)
        {
        }
    }
}

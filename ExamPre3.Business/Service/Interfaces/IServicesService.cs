using ExamPre3.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamPre3.Business.Service.Interfaces
{
    public interface IServicesService 
    {
        Task CreateAsync(Services entity);
        Task DeleteAsync(int id);

        Task UpdateAsync (Services entity);

        Task SoftDeleteAsync(int id);

        Task<List<Services>> GetAllAsync();
        Task<Services> GetByIdAsync(int id);
    }
}

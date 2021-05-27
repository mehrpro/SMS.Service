using Microsoft.EntityFrameworkCore;
using SMS.Service.Infrastructure;

namespace SMS.Service.Repositories
{
    public interface IBirthDay : IRepository<BirthRegister>
    {

    }

    public class BirthDay : Repository<BirthRegister>, IBirthDay
    {
        private readonly DbContext db;
        public BirthDay(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (schooldbEntities)db);
        }
    }
}
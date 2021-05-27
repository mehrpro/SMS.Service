using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SMS.Service.Infrastructure;

namespace SMS.Service.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        //------Definition Private Functions Model -------------//
        IList<User> GetActiveUsers();

    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext db;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (schooldbEntities)db);
        }

        public IList<User> GetActiveUsers()
        {
            var users = GetAll().ToList();
            return users;
        }
    }
}

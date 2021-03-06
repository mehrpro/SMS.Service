using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMS.Service.Repositories;

namespace SMS.Service.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()

    {

        #region Fileds
        protected readonly DbContext db;

        #endregion

        #region Ctor
        public UnitOfWork()
        {
            db = new TContext();
        }

        #endregion

        #region Implement

        public void Commit()
        {
            db.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return db.SaveChangesAsync();
        }

        #endregion

        #region Repositories
        private UserRepository userRepository;
        private BirthDay _birthDay;

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public BirthDay BirthDay
        {
            get
            {
                if (_birthDay==null)
                {
                    _birthDay = new BirthDay(db);
                }

                return _birthDay;
            }
        }

        #endregion

        #region Dispose

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}

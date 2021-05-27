using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMS.Service.Repositories;

namespace SMS.Service.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        //1-Begin TransAction  2-Commit(SaveChange) 3-RollBack
        UserRepository UserRepository { get; } //Read Only
        BirthDay BirthDay { get; }//Read Only
        void Commit();
        Task<int> CommitAsync();


    }
}

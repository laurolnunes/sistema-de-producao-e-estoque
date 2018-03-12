using System;
using SPE.Domain.Core.Commands;

namespace SPE.Domain.Products.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
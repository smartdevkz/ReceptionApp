using ReceptionApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionApp.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IVisitorRepository Visitors { get; }
        int Complete();
    }
}

using ReceptionApp.Data.Infrastructure;
using ReceptionApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReceptionDbContext _context;

        public UnitOfWork(ReceptionDbContext context)
        {
            this._context = context;
            this.Visitors = new VisitorRepository(context);
        }

        public IVisitorRepository Visitors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

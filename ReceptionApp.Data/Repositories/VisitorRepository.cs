using Microsoft.EntityFrameworkCore;
using ReceptionApp.Data.Infrastructure;
using ReceptionApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionApp.Data.Repositories
{
    public class VisitorRepository : RepositoryBase<Visitor>, IVisitorRepository
    {
        public VisitorRepository(DbContext dbContext) : base(dbContext) { }
    }

    public interface IVisitorRepository : IRepository<Visitor>
    {

    }
}

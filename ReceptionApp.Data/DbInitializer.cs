using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(ReceptionDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Visitors.Any())
            {
                context.Visitors.Add(new Model.Visitor()
                {
                    FirstName = "Мусаходжаев",
                    LastName = "Райымбек",
                    IsMale = true,
                    VisitDate = DateTime.Now,
                    BirthDate = new DateTime(1995, 5, 25)
                });
                context.Visitors.Add(new Model.Visitor()
                {
                    FirstName = "Шамшенова",
                    LastName = "Сандугаш",
                    IsMale = false,
                    VisitDate = DateTime.Now,
                    BirthDate = new DateTime(1995, 12, 9)
                });
                context.SaveChanges();
            }
        }
    }
}

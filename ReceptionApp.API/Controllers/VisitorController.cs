using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptionApp.Data;
using ReceptionApp.Data.Infrastructure;
using ReceptionApp.Model;

namespace ReceptionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        public VisitorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Visitor
        [HttpGet]
        public IEnumerable<dynamic> GetVisitors()
        {
            return unitOfWork.Visitors.GetAll().Select(x => new
            {
                x.Id,
                x.FirstName,
                x.LastName,
                x.IsMale,
                BirthDate = x.BirthDate.Date.ToString("yyyy-MM-dd"),
                VisitDate = x.VisitDate.ToString("yyyy-MM-dd HH:mm")
            });
        }

        // GET: api/Visitor/5
        [HttpGet("{id}")]
        public dynamic GetVisitor(int id)
        {
            var visitor = this.unitOfWork.Visitors.Get(id);

            if (visitor == null)
            {
                return NotFound();
            }

            return new
            {
                visitor.Id,
                visitor.FirstName,
                visitor.LastName,
                visitor.IsMale,
                BirthDate = visitor.BirthDate.Date.ToString("yyyy-MM-dd"),
                visitor.VisitDate  
                //VisitDate = visitor.VisitDate.ToString("yyyy-MM-dd HH:mm")
            };
        }

        // PUT: api/Visitor/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutVisitor(int id, Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return BadRequest();
            }

            var old = this.unitOfWork.Visitors.Get(id);
            old.FirstName = visitor.FirstName;
            old.LastName = visitor.LastName;
            old.BirthDate = visitor.BirthDate;
            old.IsMale = visitor.IsMale;
            old.VisitDate = visitor.VisitDate;

            this.unitOfWork.Complete();

            return NoContent();
        }

        // POST: api/Visitor
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostVisitor(Visitor visitor)
        {
            this.unitOfWork.Visitors.Add(visitor);
            this.unitOfWork.Complete();

            return CreatedAtAction("GetVisitor", new { id = visitor.Id }, visitor);
        }

        // DELETE: api/Visitor/5
        [HttpDelete("{id}")]
        public dynamic DeleteVisitor(int id)
        {
            var visitor = this.unitOfWork.Visitors.Get(id);
            if (visitor == null)
            {
                return NotFound();
            }
            this.unitOfWork.Visitors.Remove(visitor);
            this.unitOfWork.Complete();

            return visitor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionApp.Model
{
    public class Visitor
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public bool IsMale { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }
    }
}

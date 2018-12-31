using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Department1.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepName { get; set; }

        public List<Supervisors> supervisors { get; set; }
        public List<Workers> workers { get; set; }
    }
}

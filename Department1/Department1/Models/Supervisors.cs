using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Department1.Models
{
    public class Supervisors
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SupervisorName { get; set; }
        public virtual Department department { get; set; }
        public virtual Profession professions { get; set; }
        public virtual List<Workers> workers { get; set; }
    }
}

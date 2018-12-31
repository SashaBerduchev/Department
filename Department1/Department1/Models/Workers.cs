using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Department1.Models
{
    public class Workers
    {
        public int Id { get; set; }

        [Required]
        [MaxLength]
        public string WorkerName { get; set; }
        public virtual Department department { get; set; }
        public virtual Profession professions { get; set; }
        public virtual Supervisors supervisors { get; set; }
    }
}

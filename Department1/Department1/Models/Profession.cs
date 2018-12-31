using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Department1.Models
{
    public class Profession
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NameProfession { get; set; }
        public virtual List<Supervisors> supervisor { get; set; }
        public virtual List<Workers> worker { get; set; }
    }
}

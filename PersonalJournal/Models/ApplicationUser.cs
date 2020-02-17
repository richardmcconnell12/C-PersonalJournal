using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalJournal.Models
{
    public class ApplicationUser
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}

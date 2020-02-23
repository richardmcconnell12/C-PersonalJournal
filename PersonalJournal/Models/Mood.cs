using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalJournal.Models
{
    public class Mood
    {
        [Display(Name = "Id")]
        public int MoodId { get; set; }

        [Required]
        public string Feeling { get; set; }

        [Display(Name = "Mood")]
        public ICollection<Entry> Entries { get; set; }
    }
}

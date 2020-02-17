using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalJournal.Models
{
    public class Entry
    {
        [Key]
        [Display(Name = "Id")]
        public int? EntryId { get; set; }

        public string Mood { get; set; }

        public string Entries { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }




    }
}

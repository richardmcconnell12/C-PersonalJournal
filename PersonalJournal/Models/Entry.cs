﻿using System;
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

        [Display(Name = "Mood")]
        public int MoodId { get; set; }

        public virtual Mood Feeling { get; set; }

        public string Entries { get; set; }

        [Required]
        public string UserId { get; set; }

        [Display(Name = "Created by")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }




    }
}

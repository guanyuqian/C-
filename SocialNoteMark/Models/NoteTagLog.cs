using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class NoteTagLog
    {
        [Key]
        public int NoteTagLogID { get; set; }

        [Required]
        public int NoteID { get; set; }

        [Required]
        public int TagID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class UserTagLog
    {
        [Key]
        public int UserTagLogID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int TagID { get; set; }
    }
}
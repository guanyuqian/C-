using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class Tag
    {
        [Key]
        public int TagID { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
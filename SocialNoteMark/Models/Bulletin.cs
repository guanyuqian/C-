using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class Bulletin
    {
        [Key]
        public int BulletionID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int Flag { get; set; }

        [Required]
        public string  Name { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
    }
}
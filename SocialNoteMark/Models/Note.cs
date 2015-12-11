using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }

        public string UserName { get; set; }
        [Required]
        public int PermissionType { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EditTime { get; set; }
    }
}
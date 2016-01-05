using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }

        [Required]
        [Display(Name = "问题")]
        public string Title { get; set; }

        [Display(Name = "问题描述")]
        public string QuestionDescription { get; set;}

        [Required]
        [Display(Name = "提问者")]
        public string QuestionerName { get; set; }

        [Required]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
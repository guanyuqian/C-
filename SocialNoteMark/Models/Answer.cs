using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        [Required]
        public int QuestionID { get; set; }

        [Required]
        public string AnswererName { get; set; }

        [Required]
        public string AnswerContent { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AnswerTime { get; set; }
    }
}
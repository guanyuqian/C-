using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class UserInfo
    {
        [Key]
        public int UserInfoID { get; set; }

        [Required]
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class FriendRequest
    {
        [Key]
        public int FriendRequestID { get; set; }
        [Required]
        public string FromName { get; set; }
        [Required]
        public string ToName { get; set; }
    }
}
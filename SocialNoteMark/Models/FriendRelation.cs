using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNoteMark.Models
{
    public class FriendRelation
    {
        [Key]
        public int FriendRelationID { get; set; }

        public int FromName { get; set; }

        public int ToName { get; set; }
    }
}
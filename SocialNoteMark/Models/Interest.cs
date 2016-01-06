using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNoteMark.Models
{
    class Interest
    {
        [Key]
        public int InterestID { get; set; }

        [Required]
        public int UserName { get; set; }

        [Required]
        public int BulletionID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DiscGolf.Models
{
    public class AddPlayerViewModel
    {
        public int StartedByPlayerID { get; set; }
        public int CourseID { get; set; }
        public int PlayerID { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        [StringLength(50, ErrorMessage = "Password must be less than 50 characters")]
        public string Password { get; set; }
    }
}

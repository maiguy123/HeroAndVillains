using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Models
{
   public class TeamCreate
    {
        [Required]
        public string HerosID { get; set; }
        public int Rating { get; set; }
        public string Members { get; set; }
    }
}

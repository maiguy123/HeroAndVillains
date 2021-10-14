using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Data
{
   public class Villain
    {
        [Key]
        public string VillainID { get; set; }
        [Required]
        public string PowerType { get; set; }
        [Display(Name = "PowerType")]
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Home { get; set; }
    }
}

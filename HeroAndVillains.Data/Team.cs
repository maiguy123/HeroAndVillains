using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Data
{
    public class Team
    {
        [Key]
        public string TeamID { get; set; }
        [Display(Name = "Hero")]
        public virtual Hero Hero { get; set; }
        [ForeignKey("Hero")]
        public string HeroID { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Members { get; set; }
    }
}

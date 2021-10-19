using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Data
{
    public class MetaHumans
    {
        [Key]
        public string MetaHumanID { get; set; }
        [Required]
        [Display(Name = "PowerType")]
        public string PowerType { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Home { get; set; }
       
        [ForeignKey(nameof(Arching))]
        public string ArchingID { get; set; }
        public virtual Arching Arching { get; set; }
        [ForeignKey(nameof(Team))]
        public string TeamID { get; set; }
        public virtual Team Team { get; set; }
        public Guid OwnerId { get; set; }

    }
}

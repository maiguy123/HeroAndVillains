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
        public int TeamID { get; set; }
     
        //public virtual List<MetaHumans> Members { get; set; }

        [Required]
        public string Name { get; set; }
        public int Rating { get; set; }
        public Guid OwnerId { get; set; }
    }
}

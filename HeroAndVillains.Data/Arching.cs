using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Data
{
   public class Arching
    {
        [Key]
        public string ArchingID { get; set; }
        [Required]
        public string Story { get; set; }
        public Guid OwnerId { get; set; }
    }
}

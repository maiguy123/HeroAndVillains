﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroAndVillains.Models
{
    public class MetaHumanListItem
    {
        public string PowerType { get; set; }
        public int Rating { get; set; }
        public string Home { get; set; }
        public int ArchingID { get; set; }
        public int TeamID { get; set; }
    }
}

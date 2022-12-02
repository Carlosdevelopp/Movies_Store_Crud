﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Tables
{
    public class Awards
    {
        [Key]
        public int AwardId { get; set; }    
        public string AwardTitle { get; set;}
    }
}

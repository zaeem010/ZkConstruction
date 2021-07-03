﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZkConstruction.Models
{
    public class Subsection
    {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public int Sectionid { get; set; }
            public string Name { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class EntityStatusCatalog
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}

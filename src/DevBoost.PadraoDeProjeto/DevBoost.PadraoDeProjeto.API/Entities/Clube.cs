﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBoost.PadraoDeProjeto.API.Entities
{
    public class Clube : BaseEntity
    {

        protected Clube()
        {

        }       
        
        public string Nome { get; set; }
    }
}

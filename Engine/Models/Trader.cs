﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Trader : LivingEntity
    {
        public int ID { get; }
        public Trader(int id,string name) : base( name, 9999,9999,18,9999)
        {
            ID = id;
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatNumber
{
    public class Record
    {
        
            public string Name;
            public int Difficult;
            public int Minutes;
        public int Seconds;
        public override string ToString()
        {
            return $"{Name}\t{Difficult}\t{Minutes}:{Seconds}";
        }
    }
    
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya3
{
    
    public class Testquestion
    {
        public string Q { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public string Right { get; set; }
    }

    public class Root_2
    {
        public List<Testquestion> Testquestions { get; set; }
    }


}

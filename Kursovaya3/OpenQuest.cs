using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya3
{
    public class Openquestion
    {
        public string Q { get; set; }
        public string A { get; set; }
    }

    public class Root
    {
        public List<Openquestion> questions { get; set; }
    }
}

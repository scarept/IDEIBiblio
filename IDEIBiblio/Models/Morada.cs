using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Morada
    {
        public int ID { get; set; }
        public string rua { get; set; }
        public int porta { get; set; }
        public string andar { get; set; }
        public string cod_postal { get; set; }
        public string país { get; set; }
    }
}
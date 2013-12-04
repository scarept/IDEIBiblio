using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Compra
    {
        public int ID { get; set; }
        public DateTime data { get; set; }
        public float total { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Fatura fatura { get; set; }
    }
}
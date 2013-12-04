using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Fatura
    {
        public int ID { get; set; }
        public int numero { get; set; }
        public DateTime data { get; set; }
        public DateTime vencimento { get; set; }
        public float portes { get; set; }
        public virtual IList<Linha_Fat> linha_fatura { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Fatura
    {
        public int ID { get; set; }
        public DateTime data { get; set; }
        public DateTime vencimento { get; set; }
        public float portes { get; set; }
        public virtual IList<Linha_Doc> linha_fatura { get; set; }

        public Fatura(Encomenda enco)
        {
            linha_fatura = enco.linhas;
            portes = enco.Portes;
            data = DateTime.Now;
            vencimento = DateTime.Now;
        }
    }
}
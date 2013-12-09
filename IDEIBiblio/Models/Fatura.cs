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

        public Fatura() { }
        public Fatura(Encomenda enco)
        {
            linha_fatura = new List<Linha_Doc>();
            foreach (Linha_Doc l in enco.linhas)
            {
                Linha_Doc tmp = new Linha_Doc();
                tmp.preço_unitário = l.preço_unitário;
                tmp.produto = l.produto;
                tmp.qtd = l.qtd;

                linha_fatura.Add(tmp);
            }
            portes = enco.Portes;
            data = DateTime.Now;
            vencimento = DateTime.Now;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Encomenda
    {
        
        public int ID { get; set; }
        public DateTime data { get; set; }
        public int numero { get; set; }
        public Compra compra { get; set; }
        public IList<Linha_Doc> linhas { get; set; }
        public Cliente cliente { get; set; }
    }
}
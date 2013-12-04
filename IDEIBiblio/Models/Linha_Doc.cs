using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Linha_Doc
    {
        public int ID { get; set; }
        public virtual Produto produto { get; set; }
        public float qtd { get; set; }


    }
}
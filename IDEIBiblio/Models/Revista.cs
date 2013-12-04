using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Revista : Produto
    {
        public int numero { get; set; }
        public DateTime edição { get; set; }
        public string país { get; set; }
        public virtual Tipo_Pub tipo_publicação { get; set; }
        public virtual Cat_Revista categoria { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string titulo { get; set; }
        public string editora { get; set; }
        public float preco { get; set; }

        public virtual Gestor_P gestor_produto { get; set; }
    }
}
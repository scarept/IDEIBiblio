using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Gestor_P
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public virtual IList<Produto> produtos { get; set; }
    }
}
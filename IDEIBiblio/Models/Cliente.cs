using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public int nif { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string username { get; set; }
        public string Password { get; set; }
        public virtual Morada morada { get; set; }
        public virtual IList<Compra> compras { get; set; }
    }
}
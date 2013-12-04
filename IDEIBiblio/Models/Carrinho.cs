using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Carrinho
    {
        public int ID { get; set; }
        public IList<Item_Carrinho> linhas { get; set; }
    }
}
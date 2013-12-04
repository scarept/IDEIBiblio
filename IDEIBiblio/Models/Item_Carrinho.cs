using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Item_Carrinho
    {
        public int ID { get; set; }
        public Produto produto { get; set; }
        public int qtd { get; set; }
    }
}
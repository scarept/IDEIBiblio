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


        public void AdicionarAoCarrinho(Produto prod, int quant)
        {
            
            Boolean flag = false;
            foreach (Item_Carrinho t in linhas)
            {
                if (t.produto == prod)
                {
                    t.qtd = t.qtd + quant;
                    flag = true;
                }
            }

            if (flag == false)
            {
                //Cria uma nova linha de compra caso esta nao exista
                Item_Carrinho linha = new Item_Carrinho();
                linha.produto = prod;
                linha.qtd = quant;
                linhas.Add(linha);
            }
            //PERSISTIR CASO SEJA PARA TRATAR O CARRINHO NA BD
            //storeDB.SaveChanges();
        }

        public void RemoverDoCarrino(Produto prod)
        {
            Boolean flag = false;
            foreach (Item_Carrinho t in linhas)
            {
                if (t.produto == prod)
                {
                    linhas.Remove(t);
                    flag = true;
                }
            }
        }
    }
}
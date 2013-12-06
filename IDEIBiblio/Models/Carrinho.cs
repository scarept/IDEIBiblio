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
            if (linhas == null)
            {
                linhas = new List<Item_Carrinho>();
            }
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

        public bool RemoverDoCarrino(Produto prod)
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
            return flag;
        }

        public int getNItemsCarrinho()
        {
            if (linhas == null)
            {
                linhas = new List<Item_Carrinho>();
            }
            return linhas.Count;
        }

        private void resetItemsCarrino()
        {
            linhas = new List<Item_Carrinho>();
        }

        public Encomenda checkout(Cliente cli)
        {
            Encomenda novaEncomenda = new Encomenda(this,cli);
            this.resetItemsCarrino();
            return novaEncomenda;
        }

    }
}
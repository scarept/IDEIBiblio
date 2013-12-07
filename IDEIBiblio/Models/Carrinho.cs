using IDEIBiblio.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace IDEIBiblio.Models
{
    public class Carrinho
    {
        public int ID { get; set; }
        public virtual IList<Item_Carrinho> linhas { get; set; }
       
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
            if (flag)
            {
                DataContext db = new DataContext();
                db.SaveChanges();
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

        public Encomenda checkoutCarrinho(Cliente cli)
        {
            Encomenda novaEncomenda = new Encomenda(this,cli);
            this.resetItemsCarrino();
            DataContext db = new DataContext();
            try
            {
                db.Entry(this).State = EntityState.Modified;
                db.SaveChanges();
                return novaEncomenda;
            }
            catch (Exception) { return null; }
            
            
        }

    }
}
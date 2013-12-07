using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Encomenda
    {
        [Display(Name = "ID")]
        public int EncomendaID { get; set; }
        [Display(Name = "Data")]
        public DateTime data { get; set; }
        public virtual IList<Linha_Doc> linhas { get; set; }
        [Display(Name = "Cliente")]
        public virtual Cliente cliente { get; set; }
        [Display(Name = "Portes")]
        public float Portes { get; set; }
        public Logistica logistica { get; set; }

        public Encomenda() { }
         //Construtor que efetiva uma encomenda perante um carrinho de compras
        public Encomenda(Carrinho carr, Cliente cli, Logistica log)
        {
            cliente = cli;
            data = DateTime.Now;
            logistica = log;
            foreach (Item_Carrinho i_c in carr.linhas)
            {
                Linha_Doc l_d = new Linha_Doc();
                l_d.produto = i_c.produto;
                l_d.qtd = i_c.qtd;
                l_d.preço_unitário = i_c.produto.preco;
                linhas.Add(l_d);
            }
        }
    }
}
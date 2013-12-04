﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Encomenda
    {
        
        public int EncomendaID { get; set; }
        public DateTime data { get; set; }
        public virtual Compra compra { get; set; }
        public virtual IList<Linha_Doc> linhas { get; set; }
        public virtual Cliente cliente { get; set; }

        public Encomenda() { }
         //Construtor que efetiva uma encomenda perante um carrinho de compras
        public Encomenda(Carrinho carr, Cliente cli)
        {
            cliente = cli;
            data = DateTime.Now;
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
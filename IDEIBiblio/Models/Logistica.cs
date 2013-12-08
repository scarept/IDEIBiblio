using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Logistica
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string link { get; set; }

        /*Método que permite obter o custo dos portes para determinado carrinho de compras*/
        public float CalculaPortes(IList<Item_Carrinho> linhas){
            int qtdTotalProdutos = CalculoTotalProdutosNoCarrinho(linhas);
            float preço = 0;//ENVIO DE QUANTIDADES PELO WEBSERVICE e obtenção do preço
            if (this.nome == "ShippingAll")
            {
                NSShippingAll.serverShippingAllPortTypeClient proxy = new NSShippingAll.serverShippingAllPortTypeClient();
                preço = proxy.getDeliveryPrice(qtdTotalProdutos);
            }
            else if(this.nome == "LogisticaSA")
            {
                //Falta pesqusia ao webservice
                preço = 5;
            }
            return preço;
        }

        /* Método que calcula a quantidade total de produtos no carrinho de compras*/
        private int CalculoTotalProdutosNoCarrinho(IList<Item_Carrinho> linhas)
        {
            //Calculo de todos os items do carrinho(Pressoposto que logistica calcula preços por quantidade de artigos a encviar)
            int qtdArtigos = 0;
            foreach (Item_Carrinho tmp in linhas)
            {
                qtdArtigos += tmp.qtd;
            }
            return qtdArtigos;
        }
    }
}
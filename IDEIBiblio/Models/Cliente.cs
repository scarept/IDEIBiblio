using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Cliente
    {
        [Display(Name = "Nº Cliente")]
        public int ID { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Numero de contribuinte")]
        [DataType(DataType.Text)]
        public int nif { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string telefone { get; set; }
        [Display(Name = "Morada")]
        public virtual Morada morada { get; set; }
        public virtual IList<Compra> compras { get; set; }
        public virtual Carrinho carrinho { get; set; }
        public virtual int profile { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Gestor_P
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string Password { get; set; }
        public virtual IList<Produto> produtos { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Administrador
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        public string nome { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string mail { get; set; }
        public int profile { get; set; }
    }
}
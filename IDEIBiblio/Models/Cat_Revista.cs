using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Cat_Revista
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
    }
}
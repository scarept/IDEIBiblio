using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Morada
    {
        public int ID { get; set; }
        [Display(Name = "Rua")]
        public string rua { get; set; }
        [Display(Name = "Porta")]
        [DataType(DataType.Text)]
        public int porta { get; set; }
        [Display(Name = "Andar")]
        public string andar { get; set; }
        [Display(Name = "Codigo Postal")]
        [DataType(DataType.PostalCode)]
        public string cod_postal { get; set; }
        [Display(Name = "País")]
        public string país { get; set; }
    }
}
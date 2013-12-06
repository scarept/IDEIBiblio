using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Revista : Produto
    {
        [Display(Name = "Numero")]
        [DataType(DataType.Text)]
        public int numero { get; set; }
        [Display(Name = "Edição")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime edição { get; set; }
        [Display(Name = "País")]
        public string país { get; set; }
        [Display(Name = "Tipo Publicação")]
        public virtual Tipo_Pub tipo_publicação { get; set; }
        [Display(Name = "Categoria")]
        public virtual Cat_Revista categoria { get; set; }
    }
}
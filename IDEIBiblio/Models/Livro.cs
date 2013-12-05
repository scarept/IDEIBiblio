using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Livro : Produto
    {
        [Display(Name = "ISBN")]
        [DataType(DataType.Text)]
        public int isbn { get; set; }
        [Display(Name = "Ano de Publicação")]
        [DataType(DataType.Text)]
        public int publicação { get; set; }
        [Display(Name = "Sinopse")]
        [DataType(DataType.MultilineText)]
        public string sinopse { get; set; }
        [Display(Name = "Imagem")]
        [DataType(DataType.Upload)]
        public string path_img { get; set; }
        [Display(Name = "Categoria")]
        public virtual Cat_Livro categoria { get; set; }
    }
}
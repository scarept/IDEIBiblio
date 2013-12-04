using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Livro : Produto
    {
        public int isbn { get; set; }
        public int publicação { get; set; }
        public string sinopse { get; set; }
        public string path_img { get; set; }
        public virtual Cat_Livro categoria { get; set; }
    }
}
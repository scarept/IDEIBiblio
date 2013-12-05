using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Produto
    {
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Titulo")]
        public string titulo { get; set; }
      
        [Required]
        [Display(Name = "Editora")]
        public string editora { get; set; }
        
        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public float preco { get; set; }
        
        public virtual Gestor_P gestor_produto { get; set; }
    }
}
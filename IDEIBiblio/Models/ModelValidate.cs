using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class ModelValidate
    {
        [DataType(DataType.Text)]
        public int inteiro { get; set; }
        [DataType(DataType.Text)]
        public float d_float { get; set; }
        [DataType(DataType.Text)]
        public string texto { get; set; }
    }
}
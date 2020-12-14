using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wakanda.Models
{
    public class ProductosModel
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
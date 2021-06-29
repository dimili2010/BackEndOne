using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto1.Models
{
    public class Editorial
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre de la Editorial es Obligatorio")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Dirección es Obligatorio")]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Teléfono es Obligatorio")]
        [StringLength(50)]
        public string telefono { get; set; }
        [Required(ErrorMessage = "Email es Obligatorio")]
        [StringLength(50)]
        public string email { get; set; }
        public int MaxLibros { get; set; }

    }
}

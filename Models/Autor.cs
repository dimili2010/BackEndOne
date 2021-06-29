using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto1.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre del Autor es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Fecha de nacimiento es Obligatorio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Ciudad de nacimiento es Obligatorio")]
        public string CiudadNacimiento { get; set; }
        [Required(ErrorMessage = "Email del Autor es Obligatorio")]
        public string email { get; set; }
    }
}

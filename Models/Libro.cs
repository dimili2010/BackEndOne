using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto1.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Título del libro es Obligatorio")]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Año es Obligatorio")]
        public int Anno { get; set; }
        [Required(ErrorMessage = "Género es Obligatorio")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Número de página es Obligatorio")]
        public int NumPaginas { get; set; }          
        public virtual Autor Autor { get; set; }
        public virtual Editorial Editorial { get; set; }
    }
}

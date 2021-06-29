using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Services
{
    public interface ILibrosRegistradosService
    {
        int GetMaxLibroRegistrados(Editorial editorial);
        void AddLibroRegistrado(Editorial editorial);
        void InitValues(List<Libro> libroList);
    }
}

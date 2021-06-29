using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Services
{
    public interface IDataService
    {
        List<Libro> LibroList { get; set; }
        List<Autor> AutorList { get; set; }
        List<Editorial> EditorialList { get; set; }
        List<Libro> InitializeData();
        Libro GetLibroById(int? id);
        void AddLibro(Libro libro);
        void AddAutor(Autor autor);
        void AddEditorial(Editorial editorial);
    }
}

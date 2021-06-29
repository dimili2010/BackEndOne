using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Services
{
    public class DataService: IDataService
    {
        public List<Libro> LibroList { get; set; }
        public List<Autor> AutorList { get; set; }
        public List<Editorial> EditorialList { get; set; }

        public void AddLibro(Libro libro)
        {
            LibroList.Add(libro);           
        }

        public void AddAutor(Autor autor)
        {
            AutorList.Add(autor);
        }

        public void AddEditorial(Editorial editorial)
        {
            EditorialList.Add(editorial);
        }

        public List<Libro> InitializeData()
        {
           
            LibroList = new List<Libro>()
            {
                new Libro(){Id = 1, Titulo = "Voragine", Anno = 1980, Genero = "Drama", NumPaginas= 300,
                     Autor = new Autor() {Id=1},
                     Editorial = new Editorial() {Id=1}
                    },
                    
                new Libro(){Id = 2, Titulo = "Maria", Anno = 1990, Genero = "Romantico", NumPaginas= 350,
                     Autor = new Autor() {Id=2},
                     Editorial = new Editorial() {Id=2}
                },                    
                new Libro(){Id = 3, Titulo = "100 años de Soledad", Genero = "Drama", NumPaginas = 500,
                    Autor = new Autor() {Id=3},
                    Editorial = new Editorial() {Id=1}
}
            };

            AutorList = new List<Autor>()
            {
                new Autor() {Id=1, Nombre = "Jose Rivera", CiudadNacimiento = "Rivera", FechaNacimiento = Convert.ToDateTime("06/03/1888"), email = "jose@b.com" } ,
                new Autor() {Id = 2, Nombre = "Jorge Isaac", CiudadNacimiento = "Cali", FechaNacimiento = Convert.ToDateTime("06/03/1837"), email = "jorge@c.com" } ,
                new Autor() {Id=3, Nombre="Gabriel", CiudadNacimiento = "Aracataca", FechaNacimiento = Convert.ToDateTime("06/03/1927"), email = "gabriel@a.com" }
            };

            EditorialList = new List<Editorial>()
            {
               new Editorial() { Id = 1, Nombre = "editorial1", Direccion = "1a", email = "editorial1@a.com", MaxLibros = 2, telefono = "3001111111" }  ,
               new Editorial() { Id = 2, Nombre= "editorial2",  Direccion="22",email = "editorial2@a.com", MaxLibros=-1, telefono="3002222222" }
                
            };


            return LibroList;
        }

        public Libro GetLibroById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return LibroList.SingleOrDefault(a => a.Id == id);
            }
        }

     
    }
}

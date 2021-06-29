using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Services
{
    public class LibrosRegistradosService: ILibrosRegistradosService
    {
        public LibrosRegistradosService()
        {
            if (LibroRegistradoDictionary == null)
            {
                LibroRegistradoDictionary = new Dictionary<int, int>();
            }
        }

        public void InitValues(List <Libro> libroList)
        {
            foreach(Libro libro in libroList)
            {
                AddLibroRegistrado(libro.Editorial);
            }
        }

        private Dictionary<int, int> LibroRegistradoDictionary { get; set; }

        public void AddLibroRegistrado(Editorial editorial)
        {
            if (LibroRegistradoDictionary.ContainsKey(editorial.Id))
            {
                LibroRegistradoDictionary[editorial.Id] += 1;
            }
            else
            {
                LibroRegistradoDictionary.Add(editorial.Id, 1);
            }
        }

      
        public int GetMaxLibroRegistrados(Editorial editorial)
        {
            int quantity;
            if (LibroRegistradoDictionary.TryGetValue(editorial.Id, out quantity))
            {
                return quantity;
            }
            else
            {
                LibroRegistradoDictionary.Add(editorial.Id, 0);
                return 0;
            }          
        }
    }
}

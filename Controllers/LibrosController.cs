using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Services;

namespace Proyecto1.Controllers
{
    public class LibrosController : Controller
    {
        private IDataService _data;
        private ILibrosRegistradosService _libroRegistradosService;

        public List<Libro> LibroList { get; set; }

        public LibrosController(IDataService data, ILibrosRegistradosService libroRegistrado)
        {
            _data = data;
            _libroRegistradosService = libroRegistrado;
            
        }

        [HttpGet("/api/Libro")]
        public ActionResult<List<Libro>> GetAll()
        {
            _data.InitializeData();
            _libroRegistradosService.InitValues(_data.LibroList);
            return _data.LibroList;
            
        }

        [HttpGet("/api/Libro/{id}", Name = "GetLibro")]
        public ActionResult<Libro> GetById(int? id)
        {
            var item = _data.GetLibroById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //[HttpGet("/api/RegistrarLibro")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost(("/api/RegistrarLibro"))]
        public IActionResult Create([FromBody]Libro libro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (libro.Autor.Id > 0)
                    {
                        Autor autor = _data.AutorList.Find(x => x.Id == libro.Autor.Id);

                        if (autor != null && libro.Editorial.Id > 0)
                        {
                            libro.Autor = autor;
                            Editorial editorial = _data.EditorialList.Find(x => x.Id == libro.Editorial.Id);

                            if (editorial != null)
                            {
                                int librosRegistrados = _libroRegistradosService.GetMaxLibroRegistrados(editorial);

                                if (librosRegistrados <= editorial.MaxLibros)
                                {
                                    _libroRegistradosService.AddLibroRegistrado(editorial);
                                    libro.Id = _data.LibroList.LastOrDefault().Id + 1;
                                    _data.AddLibro(libro);
                                    libro.Editorial = editorial;
                                    return new ObjectResult(libro);
                                }
                                else
                                {
                                    return new BadRequestObjectResult("No es posible registrar el libro, se alcanzó el máximo permitido");
                                }
                            }
                            else
                            {
                                return new BadRequestObjectResult("La editorial no está registrada");
                            }
                        }
                        else
                        {
                            return new BadRequestObjectResult("El autor no está registrado");
                        }
                    }
                    else
                    {
                        return new BadRequestObjectResult("El autor no está registrado");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
    
}
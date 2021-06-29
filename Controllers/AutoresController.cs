using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Services;

namespace Proyecto1.Controllers
{
    public class AutoresController : Controller
    {
        private IDataService _data;     

        public List<Autor> AutorsList { get; set; }

        public AutoresController(IDataService data)
        {
            _data = data;           
        }

        [HttpGet("/api/Autor")]
        public ActionResult<List<Autor>> GetAll()
        {
            return _data.AutorList;
        }

       
        //[HttpGet("/api/RegistrarAutor")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost(("/api/RegistrarAutor"))]
        public IActionResult Create([FromBody]Autor autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    autor.Id = _data.AutorList.LastOrDefault().Id + 1;
                    _data.AddAutor(autor);

                    return new ObjectResult(autor);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult("Invalidos parámetros");
            }
        }
    }
}
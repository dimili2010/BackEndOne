using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;
using Proyecto1.Services;

namespace Proyecto1.Controllers
{
    public class EditorialesController : Controller
    {
        private IDataService _data;


        public List<Editorial> AutorsList { get; set; }

        public EditorialesController(IDataService data)
        {
            _data = data;
        }

        //[HttpGet("/api/Editorial")]
        //public ActionResult<List<Editorial>> GetAll()
        //{
        //    return _data.EditorialList;
        //}


        [HttpGet("/api/RegistrarEditorial")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost(("/api/RegistrarEditorial"))]
        public IActionResult Create([FromBody]Editorial editorial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    editorial.Id = _data.EditorialList.LastOrDefault().Id + 1;
                    _data.AddEditorial(editorial);
                    return new ObjectResult(editorial);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Invalidos parámetros");
            }


        }

    }
}
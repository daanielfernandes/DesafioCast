using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioCast.Context;
using DesafioCast.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly BibliotecaContexto _bibliotecaContexto;

        public LivroController(BibliotecaContexto bibliotecaContexto)
        {
            _bibliotecaContexto = bibliotecaContexto;
        }

        //Lista de livros
        [HttpGet]
        public IActionResult GetLivros()
        {
            return View("Livro", _bibliotecaContexto.Livros.ToList());
        }

        //Detalhes de um livro
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var livro = _bibliotecaContexto.Livros.FirstOrDefault(x => x.Id == id);

            if (livro == null) return NoContent();

            return View("./Views/Livro/Details.cshtml", livro);
        }

        //Metodos para adicionar um novo livro
        [HttpGet]
        [Route("NovoLivro")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("NovoLivro")]
        public ActionResult New([FromForm]Livro livro)
        {
            var index = new { id = livro.Id + 1 };

            _bibliotecaContexto.Livros.Add(livro);

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(GetLivros));
        }

        //Metodos para editar um livro
        [HttpGet]
        [Route("{id}/edit")]
        public IActionResult Edit(int id)
        {
            return View("Edit", _bibliotecaContexto.Livros.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost("{id}/edit")]        
        public ActionResult Edit(int id, [FromForm]Livro livro)
        {
            var alterar = id;

            livro.Id = alterar;

            _bibliotecaContexto.Update(livro);

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(GetLivros));
        }

        //deletar um livro
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            //var livro = _bibliotecaContexto.Livros.FirstOrDefault(x => x.Id == id);

            _bibliotecaContexto.Remove(_bibliotecaContexto.Livros.Find(id));

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(GetLivros));
        }

        
    }
}
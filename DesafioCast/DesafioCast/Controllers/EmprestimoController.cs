using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioCast.Context;
using DesafioCast.Models;
using DesafioCast.Models.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesafioCast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : Controller
    {
        private readonly BibliotecaContexto _bibliotecaContexto;

        public EmprestimoController(BibliotecaContexto bibliotecaContexto)
        {
            _bibliotecaContexto = bibliotecaContexto;
        }

        [HttpGet]
        public IActionResult Emprestimos()
        {
            ViewBag.IdCliente = this._bibliotecaContexto.Clientes.ToList().Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.IdLivro = this._bibliotecaContexto.Livros.ToList().Select(x => new SelectListItem()
            {
                Text = x.Titulo,
                Value = x.Id.ToString()
            }).ToList();

            return View("Emprestimo", _bibliotecaContexto.Emprestimos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.IdCliente = this._bibliotecaContexto.Clientes.ToList().Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.IdLivro = this._bibliotecaContexto.Livros.ToList().Select(x => new SelectListItem()
            {
                Text = x.Titulo,
                Value = x.Id.ToString()
            }).ToList();

            var emprestimo = _bibliotecaContexto.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null) return NoContent();

            return View("Details", emprestimo);
        }

        [HttpGet]
        [Route("NovoEmprestimo")]
        public ActionResult New()
        {
            ViewBag.IdCliente = this._bibliotecaContexto.Clientes.ToList().Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.IdLivro = this._bibliotecaContexto.Livros.ToList().Select(x => new SelectListItem()
            {
                Text = x.Titulo,
                Value = x.Id.ToString()
            }).ToList();

            return View();
        }
        [HttpPost]
        [Route("NovoEmprestimo")]
        public ActionResult Post([FromForm]Emprestimo emprestimo)
        {            
            var index = new { id = emprestimo.Id + 1 };

            _bibliotecaContexto.Emprestimos.Add(emprestimo);

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(Emprestimos));
        }

        [HttpGet]
        [Route("{id}/edit")]
        public IActionResult Edit(int id)
        {
            ViewBag.IdCliente = this._bibliotecaContexto.Clientes.ToList().Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.IdLivro = this._bibliotecaContexto.Livros.ToList().Select(x => new SelectListItem()
            {
                Text = x.Titulo,
                Value = x.Id.ToString()
            }).ToList();

            return View("Edit", _bibliotecaContexto.Emprestimos.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("{id}/edit")]
        public ActionResult Edit(int id, [FromForm]Emprestimo emprestimo)
        {
            var alterar = id;

            emprestimo.Id = alterar;

            _bibliotecaContexto.Emprestimos.Update(emprestimo);

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(Emprestimos));
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            
            _bibliotecaContexto.Emprestimos.Remove(_bibliotecaContexto.Emprestimos.Find(id));

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(Emprestimos));
        }
    }
}
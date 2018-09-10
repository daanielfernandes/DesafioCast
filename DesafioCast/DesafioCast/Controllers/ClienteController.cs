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
    public class ClienteController : Controller
    {

        private readonly BibliotecaContexto _bibliotecaContexto;

        public ClienteController(BibliotecaContexto bibliotecaContexto)
        {
            _bibliotecaContexto = bibliotecaContexto;
        }

        //lista de clientes
        [HttpGet]
        public ActionResult Clientes()
        {
            return View("Cliente", _bibliotecaContexto.Clientes.ToList());
        }

        // detalhes de um cliente
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var cliente = _bibliotecaContexto.Clientes.FirstOrDefault(x => x.Id == id);

            if (cliente == null) return NoContent();

            return View("Details", cliente);
        }

        // metodos para adicionar um cliente
        [HttpGet]
        [Route("novoCliente")]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        [Route("novoCliente")]
        public ActionResult Post([FromForm]Cliente cliente)
        {
            var index = new { id = cliente.Id + 1 };

            _bibliotecaContexto.Clientes.Add(cliente);

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(Clientes));
        }

        //metodos para editar um cliente
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", _bibliotecaContexto.Clientes.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("edit/{id}")]
        public ActionResult Edit(int id, [FromForm]Cliente cliente)
        {
            var alterar = id;

            cliente.Id = alterar;

            _bibliotecaContexto.Update(cliente);

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(Clientes));
        }

        //deletar um cliente
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {           
            _bibliotecaContexto.Remove(_bibliotecaContexto.Clientes.Find(id));

            _bibliotecaContexto.SaveChanges();

            return RedirectToAction(nameof(Clientes));
        }

    }
}
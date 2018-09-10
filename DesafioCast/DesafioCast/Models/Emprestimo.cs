using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        [Required]
        public DateTime DataEmprestimo { get; set; }
        [Required]
        public DateTime DataDevolucao { get; set; }
        public Livro Livro { get; set; }
        [Required]
        public int IdLivro { get; set; }
        public Cliente Cliente { get; set; }
        [Required]
        public int IdCliente { get; set; }
    }
}

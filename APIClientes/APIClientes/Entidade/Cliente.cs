using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Entidade
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }

        public string? Nome { get; set; }
        public string? NumberCpf { get; set; }

        public DateTime Nascimento { get; set; }
    }
}

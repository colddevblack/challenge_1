
using APIClientes.Entidade;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Context
{
    //Classe de conexao para Entity
    public class DataContext : DbContext
    {
        private const string Options = "ConnectionDB";


#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public DataContext(DbContextOptions<DataContext> options) : base(options)
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> Clientesdb { get; set; }

    }
}

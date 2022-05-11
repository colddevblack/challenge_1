using APIClientes.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APIClientesTests
{
    public class ClienteTest
    {
        [Fact]
        public void CriarClienteTestSucess()

        {
            // arranje  
            var cli = new Cliente()
            {
                NumberCpf = "111.444.777-35",
                Nome = "teste",
                Nascimento = DateTime.Now,
            };

            var executar = new Cliente();
           

            // Assert 
            Assert.NotNull(cli);
        }
    }

}
using Xunit;
using APIClientes.Controllers;
using System;
using System.Collections.Generic;
using APIClientes.Entidade;
using APIClientes.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;
using NSubstitute;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Web.Http;

namespace APIClientesTests
{
    public class ClientesControllerTest
    {

        
        public ILogger<ClientesController> _logger;
        public DataContext db;
        AutoFixture.Fixture _fixture = new AutoFixture.Fixture();



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
            
            
            // Assert 
            Assert.NotNull(cli);   
        }

        [Fact]
        public void ClienteTestNullFailed()

        {

            //Arranje
           //variavel nula

            //Assert
            Assert.Null(null);
        }
    }
}
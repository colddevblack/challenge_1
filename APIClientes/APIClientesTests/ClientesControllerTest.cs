using Xunit;
using APIClientes.Controllers;
using System;
using System.Collections.Generic;
using APIClientes.Entidade;
using APIClientes.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq;

namespace APIClientesTests
{
    public class ClientesControllerTest
    {

      
        [Fact]
        public void ClienteTestSucess()

        {
          
            //Arranje
            var cli = new Cliente()
            {
               
                Nome = "Teste",
                Nascimento = DateTime.Now,
                NumberCpf = "1111111111"
            };
           
           
            //Assert
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
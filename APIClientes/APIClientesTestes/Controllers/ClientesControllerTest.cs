using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using APIClientes.Validador;
using APIClientes.Context;
using APIClientes.Entidade;
using Microsoft.EntityFrameworkCore;
using Xunit;
using NUnit.Framework;
using APIClientes.Controllers;

namespace APIClientesTestes.Controllers
{
    
    public class ClientesControllerTest : ClientesController
    {
      
        [Fact]
        public void ListaClientesTest()
        {
            var controller = new ClientesController();
            var listacli = controller.ListaClientes();

            Assert.NotNull(listacli);

        }
     
    }

}



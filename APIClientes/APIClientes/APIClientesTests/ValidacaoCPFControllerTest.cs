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
    public class ValidacaoCPFControllerTest
    {

        [Fact]
        public void ValidacaoCPFValidoTestSucess()

        {

            //Arranje
            var cpf = "111.444.777-35";

            //Act
            var controller = new ValidacaoCPFController();
            var req = controller.ValidarGet(cpf);
           
            //Assert
            Assert.NotNull(req);
            Assert.Equal("CPF Valido " + cpf, req);
        }

        [Fact]
        public void ValidacaoCPFInvalidoTestSucess()

        {

            //Arranje
            var cpf = "0000000";

            //Act
            var controller = new ValidacaoCPFController();
            var req = controller.ValidarGet(cpf);

            //Assert
            Assert.NotNull(req);
            Assert.Equal("CPF Invalido ", req);
        }
    }
}
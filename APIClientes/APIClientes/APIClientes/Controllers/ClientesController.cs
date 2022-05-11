using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using APIClientes.Validador;
using APIClientes.Context;
using APIClientes.Entidade;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public ILogger<ClientesController> _logger;
        public  DataContext db;

        public ClientesController(DataContext conect, ILogger<ClientesController> logger)
        {
            db = conect;
            _logger = logger;
        }

       


        //POST api/ClientesController/CriaClientes
        [HttpPost]
        public HttpStatusCode CriarClientes(string CPF, string name, DateTime nasc)
        {
            var excut = new CpfUtils();
            try
            {
                var model = new Cliente();
                if (excut.IsValid(CPF) == true)
                {
                    model.NumberCpf = CPF;
                    model.Nome = name;
                    model.Nascimento = nasc;
                    db.Clientesdb.Add(model);
                    db.SaveChanges();
                    _logger.LogInformation("Endpoint  registro" + model);
                    return HttpStatusCode.Created;
                    
                }
                if (excut.IsValid(CPF) == false)
                {
                    _logger.LogInformation("Endpoint  registro CPF invalido" + model);
                    return HttpStatusCode.UnprocessableEntity;
                    
                }
                else
                {
                    _logger.LogInformation("Endpoint  registro CPF badrequest" + model);
                    return HttpStatusCode.BadRequest;
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning("erro" + ex);
                throw ex;
            }
           
        }
        // PUT api/ClientesController/EditarClientes
        [HttpPut]
        public HttpStatusCode EditarClientes(string cpf, string name, DateTime nasc)
        {
            CpfUtils excut = new CpfUtils();

            var usuario = (from u in db.Clientesdb where (cpf != null ? u.NumberCpf == cpf : 0 == 0) select u).Single();

            try
            {
                if (usuario.NumberCpf == cpf)
                {

                    usuario.Nome = name;
                    usuario.Nascimento = nasc;
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return HttpStatusCode.Accepted;
                }
                else
                {
                    return HttpStatusCode.UnprocessableEntity;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET api/ClientesController/ListaClientes

        [HttpGet]
        public List<Cliente> ListaClientes()
        {
            try
            {
                return db.Clientesdb.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET api/ClientesController/BuscarClientes

        [HttpGet]
        public Cliente BuscasCliente(string cpf)
        {
                try
                {
                    // consulta linq
                    var usuario = (from u in db.Clientesdb where (cpf != null ? u.NumberCpf == cpf : 0 == 0) select u).Single();

                    return usuario;
                }
                catch (Exception ex)
                {
                    throw  ex;
                } 
        }



        // DELETE: api/ClientesController/DeleteCliente
        
        [HttpDelete]
        public HttpStatusCode DeleteCliente(string cpf)
        {
            try
            {
                // consulta linq
                var usuario = (from u in db.Clientesdb where (cpf != null ? u.NumberCpf == cpf : 0 == 0) select u).Single();
                int id = usuario.id;
                var cli = db.Clientesdb.Find(id);
                db.Clientesdb.Remove(cli);
                db.SaveChanges();
                return HttpStatusCode.Accepted;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

}



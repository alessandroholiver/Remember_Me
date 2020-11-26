using API_Remember.Business.Interface;
using API_Remember.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Remember.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CadastroController : Controller
    {
        private ICadastroBusiness _cadastroBusiness;

        public CadastroController(ICadastroBusiness cadastro)
        {
            _cadastroBusiness = cadastro;
        }

      

       /// <summary>
       /// Método responsável pelo cadastro de novos usuários
       /// </summary>
       /// <param name="user"></param>
       /// <response code="200">OK </response>
       
        [HttpPost, AllowAnonymous]
        public IActionResult CadastrarUsuario([FromBody] User user)
        {
            return _cadastroBusiness.CadastrarUsuario(user);
        }


     
    }
}

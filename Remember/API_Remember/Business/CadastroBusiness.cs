using API_Remember.Business.Interface;
using API_Remember.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Remember.Business
{
    public class CadastroBusiness : ICadastroBusiness
    {
        public ActionResult CadastrarUsuario(User _user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> RetornaUsuarios()
        {
            throw new NotImplementedException();
        }

        public void ValidarUser(User _user)
        { 
        
        }
    }
}

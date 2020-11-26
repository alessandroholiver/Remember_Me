using API_Remember.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Remember.Business.Interface
{
  public interface ICadastroBusiness
    {
        ActionResult CadastrarUsuario(User user);
        IEnumerable<User> RetornaUsuarios();

    }
}

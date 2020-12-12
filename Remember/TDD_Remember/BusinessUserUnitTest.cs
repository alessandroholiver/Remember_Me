using API_Remember.Business;
using API_Remember.Business.Interface;
using API_Remember.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TDD_Remember
{
   public class BusinessUserUnitTest
    {

        //Testando caso o login do usuario esteja vazio ou nulo, resultado tem que ser falso

        [Fact]
        public void ValidaLoginUsuario()
        {
            User usuario = new User();
            usuario.Password = "";

        //    CadastroBusiness cad = new CadastroBusiness();

        //    //Act
        //    var retorno = cad.ValidarUser(usuario);

        //    //Assert
        //    Assert.Equal(false, retorno);
        }


    }
}

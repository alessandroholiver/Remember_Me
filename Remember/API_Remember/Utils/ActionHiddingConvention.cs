using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Remember.Utils
{
    public class ActionHiddingConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            //throw new NotImplementedException();
        }
    }
}

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
            if (action.ActionName == "Get" && action.Controller.ControllerName == "WeatherForecast")
                action.ApiExplorer.IsVisible = false;
        }

        public void Apply(ControllerModel controller)
        {
            //if (controller.ControllerName == "WeatherForecast")
            //    controller.ApiExplorer.IsVisible = false;
        }
    }
}

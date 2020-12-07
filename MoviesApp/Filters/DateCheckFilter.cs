using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MoviesApp.Filters
{
    public class DateCheckFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var age = DateTime.Parse(context.HttpContext.Request.Form["BirthDate"]).Year;
            if ( age > 2013 && age < 1921) 
                context.Result = new BadRequestResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}

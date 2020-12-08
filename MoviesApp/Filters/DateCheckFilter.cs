using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MoviesApp.Filters
{
    public class DateCheckFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var birthDate = DateTime.Parse(context.HttpContext.Request.Form["BirthDate"]);
            var currentDate = DateTime.Now.Date;
            if (birthDate.Year - currentDate.Year < 7 || birthDate.Year - currentDate.Year > 99)
                context.Result = new BadRequestResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conferences.Api.Helpers
{
    public static class Extensions
    {
        public static IActionResult Maybe<T>(this ControllerBase cb, T entity)
        {
            if (entity == null)
            {
                return new NotFoundResult();
            } else
            {
                return new OkObjectResult(entity);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PicBook.Web.ServerSide.Extensions
{
    public static class ModelStateErrorsExtension
    {
      public static IEnumerable<string> GetModelErrorEnumerable(this ModelStateDictionary errorsDictionary)
      {
            return errorsDictionary?.Values.SelectMany(err => err.Errors).Select(msg => msg.ErrorMessage);
      }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PicBook.Web.ServerSide.Entities;
using PicBook.Web.ServerSide.ViewModels;

namespace PicBook.Web.ServerSide.Extensions
{
    public static class RegistrationViewmodelToAccount
    {
      public static Account AccountFromRegistrationViewmodel(this RegisterViewModel model)
      {
            return new Account
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.Firstname,
                LastName = model.Lastname,
                Deleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ProfileImageUrl = null
            };
    }
    }
}

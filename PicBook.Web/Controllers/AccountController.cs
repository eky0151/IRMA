using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PicBook.Web.Controllers
{
    //[Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
      public AccountController()
      {
          
      }
      
    }
}

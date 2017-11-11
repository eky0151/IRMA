using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PicBook.Web.ServerSide.Entities;
using PicBook.Web.ServerSide.Repository.IRepositores;

namespace PicBook.Web.Controllers
{
    //[Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
      private readonly IAccountRepository _accountRepository;
      private readonly UserManager<Account> _userManager;
      private readonly SignInManager<Account> _signInManager;
       public AccountController(IAccountRepository accountRepository, SignInManager<Account> signInManager, UserManager<Account> userManager)
      {
        _accountRepository = accountRepository;
        _signInManager = signInManager;
        _userManager = userManager;
      }

      //TODO: add viewmodels or whatever -> use Account class
      [HttpPost("register")]
      [AllowAnonymous]
      public async Task<IActionResult> Register([FromBody] dynamic model)
      {
        var acc = new Account()
        {
          UserName = model.username,
          Email = model.email,
          FirstName = model.firstname,
          LastName =  model.lastname
        };

        var suceed = await _userManager.CreateAsync(acc);
        if (suceed.Succeeded) return Ok();

        return BadRequest();
      }
      
    }
}

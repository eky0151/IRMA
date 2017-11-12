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
using PicBook.Web.ServerSide.ViewModels;
using PicBook.Web.ServerSide.Extensions;

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
          _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
          _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
          _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userRegistrationAccount = model.AccountFromRegistrationViewmodel();

            var result = await _userManager.CreateAsync(userRegistrationAccount, model.Password);

            if (!result.Succeeded) return BadRequest();

            return new OkResult();
        }
      
      }
}

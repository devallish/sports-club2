//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Devallish.SportsClub.Models;
//using System.Threading.Tasks;
//using Devallish.SportsClub.DTOs;

//namespace Devallish.SportsClub.Controllers
//{
//    [AllowAnonymous]
//    [Route("api/[controller]")]
//    public class AccountsController : Controller
//    {
//        private readonly UserManager<Account> _userManager;
//        private readonly SignInManager<Account> _signInManager;
//        private readonly ILogger<AccountController> _logger;

//        public AccountController(
//            UserManager<Account> userManager,
//            SignInManager<Account> signInManager,
//            ILogger<AccountController> logger)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _logger = logger;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [RequireHttps]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Register(AccountSignInDetails signInDetails)
//        {
//            IActionResult result;

//            if (ModelState.IsValid)
//            {
//                var account = new Account() { UserName = signInDetails.Email, Email = signInDetails.Email };
//                var createUserResult = await _userManager.CreateAsync(account, signInDetails.Password);
//                if (createUserResult.Succeeded)
//                {
//                    await _signInManager.SignInAsync(account, isPersistent: false);
//                    _logger.LogInformation(ControllerEventIds.Register, $"User Registered with {signInDetails.Email}");

//                    result = Ok();
//                }
//                else
//                {
//                    _logger.LogWarning(ControllerEventIds.RegisterFailed, $"User Registration failed with {signInDetails.Email}");
//                    foreach (var error in createUserResult.Errors)
//                    {
//                        _logger.LogWarning(ControllerEventIds.RegisterFailed, $"{error.Code}: {error.Description}");
//                    }
//                    result = StatusCode(500, "Unable to register");
//                }
//            }
//            else
//            {
//                _logger.LogWarning(ControllerEventIds.RegisterFailed, $"User Registration failed - ModelState is invalid");
//                foreach (var message in ModelState)
//                {
//                    _logger.LogWarning(ControllerEventIds.RegisterFailed, $"Model State {message.Key} - {message.Value}");
//                }
//                // TODO: is this the right thing to do?
//                result = BadRequest(ModelState);
//            }

//            return result;
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> SignIn(AccountSignInDetails account)
//        {
//            IActionResult result;

//            if (ModelState.IsValid)
//            {
//                // TODO: the lockoutOnFailure??
//                var signInResult = await _signInManager.PasswordSignInAsync(
//                    account.Email, account.Password, 
//                    account.RememberMe, lockoutOnFailure: false);

//                if (signInResult.Succeeded)
//                {
//                    _logger.LogInformation(ControllerEventIds.SignIn, $"Account Signed In: {account.Email}");
//                    result = Ok();

//                }else if (signInResult.IsNotAllowed)
//                {
//                    _logger.LogWarning(ControllerEventIds.SignInFailed, $"Account Sign In failed - sign in result - not allowed.");
//                    result = Unauthorized();
//                }else if (signInResult.IsLockedOut)
//                {
//                    _logger.LogWarning(ControllerEventIds.SignInFailed, $"Account Sign In failed - sign in result - account locked out.");
//                    result = Unauthorized();
//                }else
//                {
//                    _logger.LogWarning(ControllerEventIds.SignInFailed, $"Account Sign In failed - sign in result - undefined result.");
//                    result = StatusCode(500, "Unable to sign in.");
//                }
//            }
//            else
//            {
//                _logger.LogWarning(ControllerEventIds.SignInFailed, $"Account Sign In failed - ModelState is invalid");
//                foreach (var message in ModelState)
//                {
//                    _logger.LogWarning(ControllerEventIds.SignInFailed, $"Model State {message.Key} - {message.Value}");
//                }
//                // TODO: is this the right thing to do?
//                result = BadRequest(ModelState);
//            }
//            return result;
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> SignOut()
//        {
//            await _signInManager.SignOutAsync();
//            _logger.LogInformation(ControllerEventIds.SignOut, "User logged out.");
//            return Ok();
//        }
//    }
//}

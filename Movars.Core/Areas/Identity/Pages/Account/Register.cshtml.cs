// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Movars.Core.Models;
using Movars.Core.Models.DTOs;
using Movars.Core.Models.ViewModels;
using Movars.Core.Services.Interfaces;
using NuGet.Common;

namespace Movars.Core.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;
        private readonly INotificationService _notify;
        private readonly IMailService _mailService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IConfiguration config,
            INotificationService notify,
            IMailService mailService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _config = config;
            _notify = notify;
            _mailService = mailService;
        }


        [BindProperty]
        public RegisterOwnerViewModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/Dashboard");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {

                var user = CreateUser(); //creates a user object

                // update user with Inout values
                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                user.UserName = Input.Email;

                // Assign values based on roles
                if(Input.Role == RoleType.Owner)
                {
                    user.FirstName = Input.FirstName;
                    user.LastName = Input.LastName;
                }
                else if(Input.Role == RoleType.Mover)
                {
                    user.CompanyName = Input.CompanyName;
                    user.BusinessRegNo = Input.BusinessRegNo;
                }

                // create and add user
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);

                    // add user to role
                    await _userManager.AddToRoleAsync(user, Input.Role.ToString());                    

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    //var uriBuilder = new UriBuilder(_config["ReturnPaths:ConfirmEmail"]);
                    //var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                    //query["token"] = code;
                    //query["email"] = Input.Email;
                    //uriBuilder.Query = query.ToString();
                    //var urlString = uriBuilder.ToString();

                    var firstName = user.FirstName;
                    var placeholders = new Dictionary<string, string>
                    {
                        ["{Message}"] = "Thank you for signing up. To get started, you need to confirm your email. Please click on the button below to continue.",
                        ["{Link}"] = callbackUrl,
                        ["{FirstName}"] = char.ToUpper(firstName[0]) + firstName.Substring(1)
                    };
                    var mail = new EmailMessage
                    {
                        Subject = "Email Confirmation",
                        Template = "ConfirmEmail",
                        PlainTextMessage = "Thank you for signing up. To get started, you need to confirm your email. Please click the link below to continue.",
                        ToEmail = new List<string> { user.Email },
                        PlaceHolders = placeholders
                    };
                    await _mailService.SendMailAsync(mail);

                    // Send an email to this new user to the email provided using a notification service


                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}

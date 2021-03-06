﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using MGO.Models;

namespace MGO.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var user = new ApplicationUser();
            var teacher = new Teacher();

            if (Email.Text == "melinda.korzaan@mtsu.edu")
            {
                teacher.UserName = Email.Text;
                teacher.Email = Email.Text;

                var result = manager.Create(teacher, Password.Text);

                if (result.Succeeded)
                {
                    manager.AddToRole(teacher.Id, teacher.Role);
                    signInManager.SignIn(teacher, isPersistent: false, rememberBrowser: false);

                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            else
            {
                user.UserName = Email.Text;
                user.Email = Email.Text;

                var result = manager.Create(user, Password.Text);

                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                    //manager.AddToRole(user.Id, "employee");
                    
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
        }
    }
}
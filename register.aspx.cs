﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace comp2007_lesson9_mon
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnectionEF
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = txtUName.Text };
            
            IdentityResult result = manager.Create(user, txtPass.Text);

            if (result.Succeeded)
            {
                lblStatus.Text = string.Format("User {0} was created successfully!", user.UserName);
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                Response.Redirect("/admin/main.aspx");

            }
            else
            {
                lblStatus.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Net;

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Cookies;

public partial class PruebaGDE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.IsAuthenticated)
        {
            this.loginAlertaInvalido.Visible = false;
           
        }
        else
        {
            this.loginAlertaInvalido.Visible = true;
           
        }

        
       

        if (User.Identity.IsAuthenticated)
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

            Claim access_token = claimsIdentity.Claims.First(x => x.Type == "access_token");
            //string accessToken =  HttpContext.GetTokenAsync("access_token");
            //string idToken =  HttpContext.GetTokenAsync("id_token");
            //AuthenticationHeaderValue _authHeader = new AuthenticationHeaderValue("Bearer", access_token.Value);
            //ConsumeExternalAPI(_authHeader);
        }

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            HttpContext.Current.GetOwinContext().Authentication.Challenge(
              new AuthenticationProperties { RedirectUri = "/" },
              CookieAuthenticationDefaults.ReturnUrlParameter);
        }
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
    }
    /*
    protected void LogIn(object sender, EventArgs e)
    {
      
                List<Claim> claims = GetClaims();     //Get the claims from the headers or 
                                                      //db or your user store
                if (null != claims)
                {
                    SignIn(claims);

                    //LoggingHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }

               
           
    }

    private List<Claim> GetClaims()
    {
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Email, "fer@gmail.com"));
        claims.Add(new Claim(ClaimTypes.Name, "Fernando"));
        claims.Add(new Claim(ClaimTypes.Name, "Caino"));

        var roles = new[] { "Admin", "Citizin", "Worker" };
        var groups = new[] { "Admin", "Citizin", "Worker" };

        /*foreach (var item in roles)
        {
            claims.Add(new Claim(DemoIdentity.RolesClaimType, item));
        }
        foreach (var item in groups)
        {
            claims.Add(new Claim(DemoIdentity.GroupClaimType, item));
        }
        return claims;
    }

    private void SignIn(List<Claim> claims)//Mind!!! This is System.Security.Claims not WIF claims
    {
       // var claimsIdentity = new DemoIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

        //This uses OWIN authentication
        ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

        AuthenticationManager.Unregister(DefaultAuthenticationTypes.ExternalCookie);
        AuthenticationManager.Register(new AuthenticationProperties()
        { IsPersistent = true }, claimsIdentity);

        

        Claim access_token = claimsIdentity.Claims.First(x => x.Type == "access_token");
        //HttpContext.User = new DemoPrincipal(AuthenticationManager.AuthenticationResponseGrant.Principal);
    }*/


}
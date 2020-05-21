using System;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin.Security.Keycloak;
using System.Web.Configuration;

[assembly: OwinStartup(typeof(Startup))]

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        const string persistentAuthType = CookieAuthenticationDefaults.AuthenticationType;
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = persistentAuthType
        });
        app.SetDefaultSignInAsAuthenticationType(persistentAuthType);

        app.UseKeycloakAuthentication(new KeycloakAuthenticationOptions
        {
            Realm = WebConfigurationManager.AppSettings["RealmId"],
            ClientId = WebConfigurationManager.AppSettings["ClientId"],
            ClientSecret = WebConfigurationManager.AppSettings["ClientSecret"],
            KeycloakUrl = WebConfigurationManager.AppSettings["Authority"],
            AuthenticationType = persistentAuthType,
            SignInAsAuthenticationType = persistentAuthType,
            AllowUnsignedTokens = false,
            //DisableIssuerSigningKeyValidation = false,
            //CallbackPath = "/",
            //VirtualDirectory = "PruebaGDE.aspx",
            DisableIssuerValidation = false,
            DisableAudienceValidation = false,
            TokenClockSkew = TimeSpan.FromSeconds(2)
            //ResponseType = "token id_token"
        });
        /*
        app.UseCors(CorsOptions.AllowAll);
        OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
        {

            TokenEndpointPath = new PathString("/token"),
            Provider = new ApplicationAuthProvider(),
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
            AllowInsecureHttp = true
        };
        app.UseOAuthAuthorizationServer(option);
        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        */
    }
}

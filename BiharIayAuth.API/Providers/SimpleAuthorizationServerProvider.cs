using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using MySql.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BiharIayAuth.API.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                bool valid = Membership.ValidateUser(context.UserName, context.Password);
                //if (!context.UserName.Equals("abc") || !context.Password.Equals("123"))
                if (!valid)
                {

                    context.SetError("invalid_grant", "The username or password is incorrect.");
                    return;
                }
                string roles = String.Join(",", Roles.GetRolesForUser(context.UserName));
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", roles));

                context.Validated(identity);
            }
            catch(Exception ee){
                context.SetError("invalid_grant", "The username or password is incorrect.");
                return;
            }

        } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeService.Models
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                //Base64 encode
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;

                //to Decode Token
                string DecodeToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));

                //username:password fromat in token
                string[] userNpass = DecodeToken.Split(':');
                string username = userNpass[0];
                string password = userNpass[1];


                if (EmployeeSecurity.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                .CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }

            }
            

        }
    }
}
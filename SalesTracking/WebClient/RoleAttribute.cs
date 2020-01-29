namespace WebClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;

    using BLL;

    public class RoleAttribute : Attribute
    {
        private readonly ClientService clientService = new ClientService();

        private readonly ICollection<string> roles;

        public RoleAttribute(params string[] roles)
        {
            this.roles = roles;
        }

        public Task<HttpResponseMessage> FilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken, 
            Func<Task<HttpResponseMessage>> continuation)
        {
            IPrincipal principal = actionContext.RequestContext.Principal;

            var client = clientService.GetClientByLogin(principal.Identity.Name);

            if (principal == null ||
                !(roles).Contains(client.Credentials.Role.Name))
            {
                return Task.FromResult<HttpResponseMessage>(actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
            }
            else
            {
                return continuation();
            }
        }
    }
}
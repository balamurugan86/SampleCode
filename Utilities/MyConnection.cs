using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ToastrSignalR.Utilities
{
    public class MyConnection : PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            // Broadcast data to all clients
            return Connection.Broadcast(data,"95d1284b-279c-45cd-bb93-59f4d7bc7c9a");
        }

        public class AuthenticatedConnection : PersistentConnection
        {
            protected override bool AuthorizeRequest(IRequest request)
            {
                return request.User.Identity.IsAuthenticated;
            }
        }
    }
}
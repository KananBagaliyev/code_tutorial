using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_tutorial.Hubs
{
    public class ChatHub:Hub
    {
        public string GetConnectionId() => Context.ConnectionId;
    }
}

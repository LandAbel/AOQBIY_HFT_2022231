using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AOQBIY_HFT_2022231.Endpoint.Services
{
    public class SignalRHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Conected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Disconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}

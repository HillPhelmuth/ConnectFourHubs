using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectFourHubs.Hubs
{
    public class GameHub : Hub
    {
        public async Task JoinGroup(string groupName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            var message = $"{userName} has joined game: {groupName}";
            await Clients.Groups(groupName).SendAsync("groupMessage", message);
            await Clients.Others.SendAsync("sendGroup", groupName);
        }
        public async Task SendMove(int row, int column, string groupName)
        {
            await Clients.OthersInGroup(groupName).SendAsync("sendMove", row, column);
            var message = "Your opponent moved!";
            await Clients.OthersInGroup(groupName).SendAsync("groupMessage", message);
        }
        public async Task<bool> GroupExists(string groupName)
        {
            if (Context.Items.ContainsKey(groupName))
                return (bool)await Task.FromResult(Context.Items[groupName]);
            return await Task.FromResult(false);
        }
        
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PersonalSite.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }

        public async Task CreateChatRoomGroup(string chatRoomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomName);

            await Clients.Group(chatRoomName).SendAsync("Join", $"{Context.ConnectionId} has joined {chatRoomName}");
        }
    }
}

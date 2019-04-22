using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using PersonalSite.Data;
using PersonalSite.Data.Models;

namespace PersonalSite.Hubs
{
    public class ChatHub : Hub
    {
        private static UserManager<ApplicationUser> _userManager;
        private IChat _chatService;

        public ChatHub(UserManager<ApplicationUser> userManager, IChat chatService)
        {
            _userManager = userManager;
            _chatService = chatService;
        }

        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userName, Context.UserIdentifier);
        }

        public async Task SendMessageToChatRoom(string userName, string[] userNames, string message)
        {
            List<string> userIds = new List<string>();
            foreach (var individual in userNames)
            {
                var user = await _userManager.FindByNameAsync(individual);
                var userId = await _userManager.GetUserIdAsync(user);
                userIds.Add(userId);
            }
            userIds.Add(Context.UserIdentifier);

            await Clients.Users(userIds).SendAsync("ReceiveMessage", userName, message);
        }

        public async Task AddUserToChatRoom(string userName, int chatRoomId)
        {
            var chatRoom = _chatService.GetChatRoomById(chatRoomId);
            var user = await _userManager.FindByEmailAsync(userName);

            await _chatService.UpdateChatUsers(chatRoom, user);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PersonalSite.Data;
using PersonalSite.Models.Chat;
using System.Collections.Generic;
using System.Linq;

namespace PersonalSite.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChat _chatService;

        public ChatController(IChat chatService)
        {
            _chatService = chatService;
        }

        public IActionResult Index()
        {
            string userName = User.Identity.Name;

            var messages = _chatService.GetFilteredByUserName(userName).Select(message => new ChatListingModel
            {
                Id = message.Id,
                Created = message.Created,
                Messages = message.ChatRoom.Messages as IEnumerable<ChatMessageModel>
            });

            ChatIndexModel model = new ChatIndexModel
            {
                ChatList = messages
            };

            return View(model);
        }

        public IActionResult New(string userName)
        {

            // TODO: return to a form for filling out
            // a new chat message between two
            // users
            return View();
        }
    }
}
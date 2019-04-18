using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalSite.Data;
using PersonalSite.Data.Models;
using PersonalSite.Models.Chat;
using System.Collections.Generic;
using System.Linq;

namespace PersonalSite.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private static UserManager<ApplicationUser> _userManager; 
        private readonly IChat _chatService;

        public ChatController(IChat chatService, UserManager<ApplicationUser> userManager)
        {
            _chatService = chatService;
            _userManager = userManager;
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
            var model = new ChatMessageModel
            {
                AuthorName = User.Identity.Name,
                AuthorId = _userManager.GetUserId(User)                
            };
            // TODO: return to a form for filling out
            // a new chat message between two
            // users
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ChatMessageModel model)
        {
            if (model.ChatRoomId == 0)
            {
                //create a new chat room, and pass the id to the model
            }

            return RedirectToAction("Room", new { model.ChatRoomId });
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalSite.Data;
using PersonalSite.Data.Models;

namespace PersonalSite.Service
{
    public class ChatService : IChat
    {
        private readonly ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ChatMessage chatMessage, ChatRoom chatRoom)
        {
            await _context.Messages.AddAsync(chatMessage);
        }

        public Task Delete(ChatMessage chatMessage)
        {
            throw new System.NotImplementedException();
        }

        public ChatMessage GetById(int id)
        {
            var message = _context.Messages.Where(m => m.Id == id)
                .First();

            return message;
        }

        public IEnumerable<ChatMessage> GetFilteredByUserName(string userName)
        {
            return _context.Messages.Include(m => m.User).Where(m => m.User.UserName == userName)
                .Include(m => m.ChatRoom).ThenInclude(c => c.Users)
                .Include(m => m.ChatRoom).ThenInclude(c => c.Messages);
        }

        public Task UpdateChatContent(int id, string newContent)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateChatUsers(ChatRoom chatRoom, ApplicationUser user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ChatMessage> GetFIlteredByChatRoomId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

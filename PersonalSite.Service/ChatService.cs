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

        public Task Create(ChatMessage chatMessage)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(ChatMessage chatMessage)
        {
            throw new System.NotImplementedException();
        }

        public ChatMessage GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ChatMessage> GetFilteredByUserName(string userName)
        {
            return _context.Messages.Include(m => m.User).Where(m => m.User.UserName == userName)
                .Include(m => m.ChatRoom).ThenInclude(c => c.Users)
                .Include(m => m.ChatRoom).ThenInclude(c => c.Messages);
        }

        public IEnumerable<ChatMessage> GetFilteredByChatUserName(string id)
        {
            throw new System.NotImplementedException();
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

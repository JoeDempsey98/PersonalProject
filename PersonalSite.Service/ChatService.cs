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

        public ChatRoom GetChatRoomById(int id)
        {
            var chatRoom = _context.ChatRooms.Where(r => r.Id == id)
                .Include(r => r.Messages)
                .Include(r => r.Users);
            return chatRoom.FirstOrDefault();
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

        public async Task UpdateChatUsers(ChatRoom chatRoom, ApplicationUser user)
        {
            chatRoom.Users.Append(user);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ChatMessage> GetFIlteredByChatRoomId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

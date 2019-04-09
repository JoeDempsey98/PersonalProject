using PersonalSite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalSite.Data
{
    public interface IChat
    {
        ChatMessage GetById(int id);
        IEnumerable<ChatMessage> GetFilteredByUserName(string id);
        IEnumerable<ChatMessage> GetFIlteredByChatRoomId(int id);

        Task Create(ChatMessage chatMessage);
        Task UpdateChatContent(int id, string newContent);
        Task UpdateChatUsers(ChatRoom chatRoom, ApplicationUser user);
        Task Delete(ChatMessage chatMessage);
    }
}

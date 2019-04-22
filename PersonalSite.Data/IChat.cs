using PersonalSite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalSite.Data
{
    public interface IChat
    {
        ChatMessage GetById(int id);
        IEnumerable<ChatMessage> GetFilteredByUserName(string userName);
        IEnumerable<ChatMessage> GetFIlteredByChatRoomId(int id);
        ChatRoom GetChatRoomById(int id);

        Task Create(ChatMessage chatMessage, ChatRoom chatRoom);
        Task UpdateChatContent(int id, string newContent);
        Task UpdateChatUsers(ChatRoom chatRoom, ApplicationUser user);
        Task Delete(ChatMessage chatMessage);
    }
}

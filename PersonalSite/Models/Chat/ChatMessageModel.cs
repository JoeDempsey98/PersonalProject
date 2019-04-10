using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalSite.Models.Chat
{
    public class ChatMessageModel
    {
        public int ChatRoomId;
        public string Content;
        public DateTime Created;
        public string AuthorName;
        public string AuthorId;
    }
}

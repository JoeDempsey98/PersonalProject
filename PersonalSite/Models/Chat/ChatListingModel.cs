using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalSite.Models.Chat
{
    public class ChatListingModel
    {
        public int Id;
        public DateTime Created;
        public IEnumerable<IdentityRole> Users;
        public IEnumerable<ChatMessageModel> Messages;
    }
}

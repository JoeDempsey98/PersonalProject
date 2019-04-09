using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalSite.Models.Chat
{
    public class ChatMessageModel
    {
        public int Id;
        public string Content;
        public DateTime Created;
        public IdentityRole User;
    }
}

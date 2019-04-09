using System;
using System.Collections.Generic;

namespace PersonalSite.Data.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public virtual IEnumerable<ApplicationUser> Users { get; set; }
        public virtual IEnumerable<ChatMessage> Messages { get; set; }
    }
}

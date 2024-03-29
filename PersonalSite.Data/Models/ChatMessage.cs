﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalSite.Data.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }
    }
}

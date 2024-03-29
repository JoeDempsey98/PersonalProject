﻿using PersonalSite.Models.Post;
using System.Collections.Generic;

namespace PersonalSite.Models.Forum
{
    public class ForumTopicModel
    {
        public string SearchQuery { get; set; }
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}

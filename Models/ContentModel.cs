using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace WebGrabDemo.Models
{
    public class ContentModel
    {
        public int AllWordsCount { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<WordModel> TopWords { get; set; }
        public List<WordModel> AllWords { get; set; }
    }
}
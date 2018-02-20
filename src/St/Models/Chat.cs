using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace St.Models
{
    public class Chat
    {
        public string ChatId { get; set; }
        public ApplicationUser Owner { get; set; }
        public ApplicationUser Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
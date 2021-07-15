using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinglePageToDo.Models
{
    public class MessageViewModel
    {
        [JsonIgnore]
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Utility
{
    public class Message
    {
        public string Text { get; set; }
        public int? Duration { get; set; }
        public bool Closeable { get; set; }
        public MessageType Type { get; set; }
        public const string MessageName = "Message"; // const : hiçbir yerde değiştirilemeyen demektir. (sabit)
    }

    public enum MessageType
    {
        Success=1,
        Warning,
        Danger

    }
}
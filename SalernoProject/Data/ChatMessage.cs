using System;
using System.Collections.Generic;

namespace SalernoProject.Data
{
    public class ChatMessage
    {
        public string message { get; set; }
        public string username { get; set; }
        public string userColor { get; set; } // Store color as a string
        private static readonly List<string> RainbowColors = new List<string>
        {
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Blue",
            "Purple",
        };

        public ChatMessage() { }

        public ChatMessage(string newMessage, string myUser, string myColor)
        {
            message = newMessage;
            username = myUser;
            userColor = myColor;
        }

        public ChatMessage(string newMessage, string myUser)
        {
            message = newMessage;
            username = myUser;

            Random random = new Random();
            int index = random.Next(RainbowColors.Count);
            userColor = RainbowColors[index];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TerrariaServerWrapper.Model;

namespace TerrariaServerWrapper.MainServices
{
    class Parser
    {
        public static ConsoleMessage ConsoleParser(string dataString)
        {
            ConsoleMessage TypedMessage = new ConsoleMessage();
            string text = Regex.Replace(dataString, "\x1B(?:[@-Z\\-_]|[[0-?]*[ -/]*[@-~])", "");
            if (text.Contains("has joined"))
            {
                string pattern = @"(.+) has joined";
                string joinedPlayer = Regex.Match(text, pattern).Groups[1].Value;
                TypedMessage.messageType = ConsoleMessage.MessageType.PlayerState;
                TypedMessage.sender = joinedPlayer;
                TypedMessage.Data = "joined";
            }
            else if (text.Contains("has left"))
            {
                string pattern = @"(.+) has left";
                string leftPlayer = Regex.Match(text, pattern).Groups[1].Value;
                TypedMessage.messageType = ConsoleMessage.MessageType.PlayerState;
                TypedMessage.sender = leftPlayer;
                TypedMessage.Data = "left";
            }
            else
            {
                TypedMessage.messageType = ConsoleMessage.MessageType.Default;
                TypedMessage.sender = "Console";
                TypedMessage.Data = text;
            }

            return TypedMessage;
        }

    }
}

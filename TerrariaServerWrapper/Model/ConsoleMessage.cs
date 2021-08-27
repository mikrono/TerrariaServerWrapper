using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaServerWrapper.Model
{
    public class ConsoleMessage
    {
        public MessageType messageType { get; set; }
        public string sender { get; set; }
        public string Data { get; set; }

        public enum MessageType
        {
            Default = 0,
            PlayerState = 1
        }
    }
}

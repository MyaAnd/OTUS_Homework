using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PrototypePattern.Classes
{
    public class AllLowerColoredTextMessage : ColoredTextMessage
    {
        public AllLowerColoredTextMessage(string text, ConsoleColor color) : base(text, color)
        {

        }

        public override void PrintMessage()
        {
            string originalText = Text;
            Text = Text.ToLower();

            base.PrintMessage();

            Text = originalText;
        }

        public override TextMessage MyCloneMethod()
        {
            return new AllLowerColoredTextMessage(Text, Color);
        }
    }
}

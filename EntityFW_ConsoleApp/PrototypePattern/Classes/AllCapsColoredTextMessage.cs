using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Classes
{
    public class AllCapsColoredTextMessage : ColoredTextMessage
    {
        public AllCapsColoredTextMessage(string text, ConsoleColor color) : base(text, color)
        {

        }

        public override void PrintMessage()
        {
            string originalText = Text;
            Text = Text.ToUpper();

            base.PrintMessage();

            Text = originalText;
        }

        public override TextMessage MyCloneMethod()
        {
            return new AllCapsColoredTextMessage(Text, Color);
        }
    }
}

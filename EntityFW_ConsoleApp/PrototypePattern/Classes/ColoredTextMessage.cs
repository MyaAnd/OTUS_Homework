using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Classes
{
    public class ColoredTextMessage : TextMessage
    {
        protected ConsoleColor Color { get; set; }

        public ColoredTextMessage(string text, ConsoleColor color) : base(text)
        {
            Color = color;
        }

        public override void PrintMessage()
        {
            var originalColor = Console.ForegroundColor;

            Console.ForegroundColor = Color;
            base.PrintMessage();

            Console.ForegroundColor = originalColor;
        }

        public override TextMessage MyCloneMethod()
        {
            return new ColoredTextMessage(Text, Color);
        }
    }
}

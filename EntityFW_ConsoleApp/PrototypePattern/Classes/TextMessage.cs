using PrototypePattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Classes
{
    public class TextMessage : IMyCloneable<TextMessage>, ICloneable
    {
        public string Text { get; set; }

        public TextMessage(string text) { Text = text; }

        public virtual void PrintMessage()
        {
            Console.WriteLine(Text);
        }

        public virtual TextMessage MyCloneMethod()
        {
            return new TextMessage(Text);
        }

        public object Clone()
        {
            return MyCloneMethod();
        }
    }
}

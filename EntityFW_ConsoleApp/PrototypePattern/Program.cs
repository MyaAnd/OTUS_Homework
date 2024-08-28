using PrototypePattern.Classes;

string message = "Hello World!";

TextMessage tm = new TextMessage(message);
tm.PrintMessage();

ColoredTextMessage coloredTextMessage = new ColoredTextMessage(message, ConsoleColor.Red);
coloredTextMessage.PrintMessage();

AllCapsColoredTextMessage allCapsColoredTextMessage = new AllCapsColoredTextMessage(message,ConsoleColor.Green);
allCapsColoredTextMessage.PrintMessage();

AllLowerColoredTextMessage allLowerColoredTextMessage = new AllLowerColoredTextMessage(message, ConsoleColor.Blue);
allLowerColoredTextMessage.PrintMessage();

Console.WriteLine();

var tmMyClone = tm.MyCloneMethod();
var coloredTextMessageMyClone = coloredTextMessage.MyCloneMethod();
var allCapsColoredTextMessageMyClone = allCapsColoredTextMessage.MyCloneMethod();
var allLowerColoredTextMessageMyClone = allLowerColoredTextMessage.MyCloneMethod();

tmMyClone.PrintMessage();
coloredTextMessageMyClone.PrintMessage();
allCapsColoredTextMessageMyClone.PrintMessage();
allLowerColoredTextMessage.PrintMessage();

Console.WriteLine();

var tmClone = tm.Clone();
var coloredTextMessageClone = coloredTextMessage.Clone();
var allCapsColoredTextMessageClone = allCapsColoredTextMessage.Clone();
var allLowerColoredTextMessageClone = allLowerColoredTextMessage.Clone();

((TextMessage)tmClone).PrintMessage();
((ColoredTextMessage)coloredTextMessageClone).PrintMessage();
((AllCapsColoredTextMessage)allCapsColoredTextMessageClone).PrintMessage();
((AllLowerColoredTextMessage)allLowerColoredTextMessage).PrintMessage();

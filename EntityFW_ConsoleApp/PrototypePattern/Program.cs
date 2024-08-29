using PrototypePattern.Classes;

string message = "Hello World!";
string message2 = "Bye bye World!";
string message3 = "Hello again";

TextMessage tm = new TextMessage(message);

ColoredTextMessage coloredTextMessage = new ColoredTextMessage(message, ConsoleColor.Red);


AllCapsColoredTextMessage allCapsColoredTextMessage = new AllCapsColoredTextMessage(message,ConsoleColor.Green);

AllLowerColoredTextMessage allLowerColoredTextMessage = new AllLowerColoredTextMessage(message, ConsoleColor.Blue);


Console.WriteLine();

var tmMyClone = tm.MyCloneMethod();
tmMyClone.Text = message2;
var coloredTextMessageMyClone = coloredTextMessage.MyCloneMethod();
coloredTextMessageMyClone.Text = message2;
var allCapsColoredTextMessageMyClone = allCapsColoredTextMessage.MyCloneMethod();
allCapsColoredTextMessageMyClone.Text= message2;
var allLowerColoredTextMessageMyClone = allLowerColoredTextMessage.MyCloneMethod();
allLowerColoredTextMessageMyClone.Text= message2;

var tmClone = tm.Clone(); ((TextMessage)tmClone).Text = message3;
var coloredTextMessageClone = coloredTextMessage.Clone(); ((ColoredTextMessage)coloredTextMessageClone).Text = message3;
var allCapsColoredTextMessageClone = allCapsColoredTextMessage.Clone(); ((AllCapsColoredTextMessage)allCapsColoredTextMessageClone).Text = message3;
var allLowerColoredTextMessageClone = allLowerColoredTextMessage.Clone(); ((AllLowerColoredTextMessage)allLowerColoredTextMessageClone).Text= message3;


tm.PrintMessage();
tmMyClone.PrintMessage();
((TextMessage)tmClone).PrintMessage();
Console.WriteLine();

coloredTextMessage.PrintMessage();
coloredTextMessageMyClone.PrintMessage();
((ColoredTextMessage)coloredTextMessageClone).PrintMessage();
Console.WriteLine();

allCapsColoredTextMessage.PrintMessage();
allCapsColoredTextMessageMyClone.PrintMessage();
((AllCapsColoredTextMessage)allCapsColoredTextMessageClone).PrintMessage();
Console.WriteLine();

allLowerColoredTextMessage.PrintMessage();
allLowerColoredTextMessageMyClone.PrintMessage();
((AllLowerColoredTextMessage)allLowerColoredTextMessageClone).PrintMessage();
Console.WriteLine();








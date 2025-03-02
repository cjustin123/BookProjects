// console prints black text on white background
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.Write("X value: ");

// colors are reversed for user input
/* the ReadLine() makes it color the entire next line */
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
int _xValue = Convert.ToInt32(Console.ReadLine());

// console prints black text on white background
// after console prints the rest of the line will be the color set by the previous ReadLine()
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.Write("Y value: ");

// user input again. back to default colors to keep it tidy
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
int _yValue = Convert.ToInt32(Console.ReadLine());

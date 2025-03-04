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

Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
if (_yValue > 0 && _xValue < 0)
{
    Console.Write("The enemy is to the northwest!");
}
else if (_yValue == 0 && _xValue < 0)
{
    Console.Write("The enemy is to the west!");
}
else if (_yValue < 0 && _xValue < 0)
{
    Console.Write("The enemy is to the southwest!");
}
else if (_yValue > 0 && _xValue ==0)
{
    Console.Write("The enemy is to the north!");
}
else if (_yValue == 0 && _xValue == 0)
{
    Console.Write("!!!!!!!!!!!!!!!!!!!!!");
}
else if (_yValue < 0 && _xValue == 0)
{
    Console.Write("The enemy is to the south!");
}
else if (_yValue > 0 && _xValue > 0)
{
    Console.Write("The enemy is to the northeast!");
}
else if (_yValue == 0 && _xValue > 0)
{
    Console.Write("The enemy is to the east!");
}
else if (_yValue < 0 && _xValue > 0)
{
    Console.Write("The enemy is to the southeast!");
}
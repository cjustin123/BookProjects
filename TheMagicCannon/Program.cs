
for (int i = 1;i <= 100;i++)
{
    if ( i % 5 == 0 && i % 3 == 0)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write($"{i}: Combined");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("\n");
    }
    else if (i % 5 == 0)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.Write($"{i}: Electric");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("\n");
    }
    else if (i % 3 == 0)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write($"{i}: Fire");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("\n");
    }
    else
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write($"{i + 1}: Normal");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("\n");
    }
}
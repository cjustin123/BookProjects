Console.Title = "The Defense Of Consolas";

Console.WriteLine("Target Row? ");
string _input = Console.ReadLine();
int _row = Convert.ToInt32(_input);
Console.WriteLine("Target Column? ");
_input = Console.ReadLine();
int _col = Convert.ToInt32(_input);
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Deploy To:");
 
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Yellow;
Console.WriteLine("");
//Console.Clear();

Console.WriteLine($"({_row},{_col-1})"); 
Console.WriteLine($"({_row-1},{_col})");
Console.WriteLine($"({_row},{_col+1})");
Console.Write($"({_row+1},{_col})");
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("\nmonkey's ass");
Console.ReadKey();

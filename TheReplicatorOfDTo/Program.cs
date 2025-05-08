Console.Title = "Replicator";
Console.Clear();
int[] _userArray = new int[5];
int[] _replicatorArray = new int[_userArray.Length];
//Get user input
Console.WriteLine("User supply 5 numbers.");
for (int i = 0;i < 5;i++)
{
    Console.Write("Enter Number: ");
    int input = Convert.ToInt32(Console.ReadLine());
    _userArray[i] = input;
    Console.Clear();
}

//User output
Console.BackgroundColor = ConsoleColor.Cyan;
Console.Write("User numbers: ");
for (int i = 0;i < _userArray.Length;i++)
{
    if (i == _userArray.Length - 1)
    {
        Console.Write(_userArray[i]);
    }
    else
    {
        Console.Write(_userArray[i] + ", ");
    } 
    _replicatorArray[i] = _userArray[i];
}
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("");

//Replicator output
Console.BackgroundColor = ConsoleColor.Magenta;
Console.Write("Replicator number: ");
for (int i = 0;i < _replicatorArray.Length;i++)
{
    if (i == _replicatorArray.Length - 1)
    {
        Console.Write(_replicatorArray[i]);
    }
    else
    {
        Console.Write(_replicatorArray[i] + ", ");
    }
}
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine("");
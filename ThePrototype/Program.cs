
Console.Title = "The Prototype";
int pilotNumber;
int hunterNumber;
do
{
    Console.Write("Pilot, pick a number between 0 and 100: ");
    pilotNumber = Convert.ToInt32(Console.ReadLine());
}
while (pilotNumber < 0 || pilotNumber > 100);

Console.Clear(); 

do 
{
    Console.Write("Hunter, guess a number: ");
    hunterNumber = Convert.ToInt32(Console.ReadLine());
    if ( hunterNumber > pilotNumber)
    {
        Console.Write($"{hunterNumber} is too high.");
    }
    else if (hunterNumber < pilotNumber)
    {
        Console.Write($"{hunterNumber} is too low.");
    }
    else
    {
        Console.Write("And boom goes the dynamite.");
    }
    Console.Write("\n");
}
while (hunterNumber != pilotNumber);

Console.Title = "The Prototype";
int pilotNumber;
do
{
    Console.Write("Pilot, pick a number between 0 and 100: ");
    pilotNumber = Convert.ToInt32(Console.ReadLine());
}
while (pilotNumber < 0 || pilotNumber > 100);
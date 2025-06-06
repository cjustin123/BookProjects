Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.Write("HI WORL");
Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine(" ");
Map _map = new Map();
_map.DisplayMap();
Console.ReadKey();






/// END OF TOP LEVEL STATEMENT/ PROGRAM.MAIN() FUNCTION
public enum RoomType { Entrance, Fountain, Empty }


public class Room
{
    public RoomType RoomType { get; private set; }
}
public class Map
{
    public int Size { get; private set; } = 4;

    public RoomType[,] RoomArray;
    public Map()
    {
        RoomArray = new RoomType[Size, Size];
        for (int x = 0; x < RoomArray.GetLength(0); x++)
        {
            for (int y = 0; y < RoomArray.GetLength(1); y++)
            {
                RoomArray[x, y] = RoomType.Empty;
            }
        }
    }
    public void DisplayMap()
    {
        for (int x = 0; x < RoomArray.GetLength(0); x++)
        {
            Console.WriteLine("");
            for (int y = 0; y < RoomArray.GetLength(1); y++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(RoomArray[x, y]);

                if (y == RoomArray.GetLength(1) - 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    continue;
                }
                else
                {

                    Console.Write(", ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
    
}






Game _game;
_game = new Game();
_game.Run();


public class Game
{
    Map _map = new Map();

    public void Run()
    {
        _map.DisplayMap();
    }
}

public record Position { public int x; public int y; } //MAKE A STRUCT
public enum RoomType { Entrance, Fountain, Empty }

public class Room
{
    public RoomType RoomType { get; private set; }
    public Position Position { get; private set; }
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
    ///////////////////////////////////////////////////////////////////
    public void DisplayMap()
    {
        for (int x = 0; x < RoomArray.GetLength(0); x++)
        {
            Console.WriteLine("");
            for (int y = 0; y < RoomArray.GetLength(1); y++)
            {

                Console.Write(RoomArray[x, y]);
                if (y == RoomArray.GetLength(1) - 1)
                {

                    continue;
                }
                else
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
    
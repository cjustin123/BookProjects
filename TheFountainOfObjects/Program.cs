

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

public struct Position { public int X, Y; }
public enum RoomType { Entrance, Fountain, Empty }

public class Room
{
    public Room(int x, int y)
    {
        Position.X = x;
        Position.Y = y;
    }
    public RoomType RoomType { get; private set; }
    public readonly Position Position;
}
public class Map
{
    public int Size { get; private set; } = 4;

    public Room[,] RoomArray;
    public Map()
    {
        RoomArray = new Room[Size, Size];
        for (int x = 0; x < RoomArray.GetLength(0); x++)
        {
            for (int y = 0; y < RoomArray.GetLength(1); y++)
            {
                Room newRoom = new Room(x, y);
                RoomArray[x, y] = newRoom;
      

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

                Console.Write(RoomArray[x, y] + $"({x}, {y})");
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
    


Game _game;
_game = new Game();
_game.Run();


public class Game
{
    Map _map = new Map();
    bool _isFountainActive = false;

    public void Run()
    {
        _map.DisplayMap();
    }
}

public struct Position { public int X, Y; }
public enum RoomType { Entrance, Fountain, Empty, Wall }

public class Room
{
    public RoomType North, South, East, West;
    // MAYBE ABSTRACT
    public Room(int x, int y)
    {
        Position.X = x;
        Position.Y = y;
    }
    public RoomType RoomType { get; private set; }
    public readonly Position Position;

    public void SetRoomType(RoomType roomType)
    {
        RoomType = roomType;
    }
}
public class Map
{
    public int Size { get; private set; } = 4;

    public Room[,] RoomArray;
    public Map()
    {
        RoomArray = new Room[Size, Size];
        BuildLevel();

    }
    private void BuildLevel()
    {
        // fountain placement
        Random rnd = new Random();
        int fountainX = rnd.Next(1, Size);
        int fountainY = rnd.Next(1, Size);
        Position fountainPosition = new Position();
        fountainPosition.X = fountainX;
        fountainPosition .Y = fountainY;

        for (int x = 0; x < RoomArray.GetLength(0); x++)
        {
            for (int y = 0; y < RoomArray.GetLength(1); y++)
            {
                Room newRoom = new Room(x, y);
                if (newRoom.Position.Equals(fountainPosition))
                {
                    newRoom.SetRoomType(RoomType.Fountain);
                }
                else if (x == 0 && y == 0)
                {
                    newRoom.SetRoomType(RoomType.Entrance);
                }
                else
                {
                    newRoom.SetRoomType(RoomType.Empty);
                }
                
                RoomArray[x, y] = newRoom;
            }
        }
    }
    ///////////////////////////////////////////////////////////////////
    public void DisplayMap()
    {
        // MAKE IT DISPLAY Y AXIS IN REVERSE ORDER
        for (int x = 0; x < RoomArray.GetLength(0); x++)
        {
            Console.WriteLine("");
            for (int y = 0; y < RoomArray.GetLength(1); y++)
            {

                Console.Write(RoomArray[x, y].RoomType + $"({x}, {y})");
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
    
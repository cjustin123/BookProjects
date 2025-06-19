using System.Runtime.CompilerServices;


Game _game;
_game = new Game();

_game.Run();


public class Game
{
    Map _map = new Map();
    Player _player = new Player();
    
    bool _isFountainActive = false;

    public void Run()
    {

        _player._map = _map;


        while (_player.IsAlive)
        {
            //Console.Clear();
            // Player checks senses of current room
            //Console.WriteLine($"Current Position: ({_player.Position.X}, {_player.Position.Y})");// UI class method
            UIManager.HeaderText(_player);
            _map.DisplayMap(_player.Position);
            //Process player input
            _player.MoveNorth();
            Console.ReadLine();
        }
    }
}
public class UIManager
{
    public static void HeaderText(Player player)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write($"Current Position: ({player.Position.X}, {player.Position.Y})");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }
}
public class Player
{
    private Position _position;
    public Map _map;
    public Position Position { get => _position; }
    public bool IsAlive { get; private set; }
    public Player()
    {
        IsAlive = true;
        _position = new Position();
        _position.X = 0;
        _position.Y = 0;
    }


    //turn into one method, passing in a value to switch over
    public void MoveNorth()
    {
       if ( _map.IsValidPosition(Position.X + 1, Position.Y))
        {
            _position.X += 1;
        }
        
    }
    public void MoveSouth()
    {
        if (_map.IsValidPosition(Position.X + 1, Position.Y))
        {
            _position.X -= 1;
        }
    }
    public void MoveEast()
    {
        if (_map.IsValidPosition(Position.X + 1, Position.Y))
        {
            _position.Y += 1;
        }
    }
    public void MoveWest()
    {
        if (_map.IsValidPosition(Position.X + 1, Position.Y))
        {
            _position.Y -= 1;
        }
    }
}

public class PlayerInput
{

}

public interface ISenses
{
    public void Sense();
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
    public bool IsValidPosition(int x, int y)
    {
        if (x >= Size || x < 0)
        {
            return false;
        }
        if (y >= Size || y < 0)
        {
            return false;
        }
        return true;
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
    public void DisplayMap(Position playerPosition)
    {
        // MAKE IT DISPLAY Y AXIS IN REVERSE ORDER
        for (int x = 0; x < RoomArray.GetLength(0); x++)
        {
            Console.WriteLine("");
            for (int y = 0; y < RoomArray.GetLength(1); y++)
            {
                if (RoomArray[x,y].Position.Equals(playerPosition))
                {
                    Console.Write("PLAYER");
                }
                else
                {
                    Console.Write(RoomArray[x, y].RoomType + $"({x}, {y})");
                }
                    

                if (y == RoomArray.GetLength(1) - 1)
                {

                    continue;
                }
                else
                {
                    Console.Write("| ");
                }
            }
        }
    }
}
    
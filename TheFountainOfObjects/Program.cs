using System.Runtime.CompilerServices;
using System;
using System.ComponentModel;


Game _game;
_game = new Game();

_game.Run();


public class Game
{
    Map _map = new Map();
    Player _player = new Player();
    PlayerInput? _playerInput;
    bool _isFountainActive = false;
    public static Game Instance;

    public Game()
    {
        Instance = this;
    }
    public void EnableFountain()
    {
        if (_map.RoomArray[_player.Position.X, _player.Position.Y].RoomType == RoomType.Fountain)
        {
            _isFountainActive = true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("The Fountain Of Objects is not in this room.");
            Console.ReadKey();
        }
    }
    public void Run()
    {

        _player.Map = _map;
        _playerInput = new PlayerInput(_player);

        while (_player.IsAlive)
        {
            //Console.Clear();
            // Player checks senses of current room
            Console.WriteLine($"Current Position: ({_player.Position.X}, {_player.Position.Y})");// UI class method
            Console.WriteLine($"Room: {_map.RoomArray[_player.Position.X, _player.Position.Y].RoomType}");
            _map.DisplayMap(_player.Position);
            //Process player input
            string playerInput = Console.ReadLine();
            _playerInput.Update(playerInput.ToLower());
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
    public Map? Map;
    public Position Position { get => _position; }
    public bool IsAlive { get; private set; }
    public Player()
    {
        IsAlive = true;
        _position = new Position();
        _position.X = 0;
        _position.Y = 0;
    }

    public void MoveNorth()
    {
        //is valid position check
        if (Map.IsValidPosition(Position.X + 1, Position.Y))
        {
            _position.X += 1;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("You hit a wall.");
            Console.ReadKey();
        }
    }
    public void MoveSouth()
    {
        if (Map.IsValidPosition(Position.X - 1, Position.Y))
        {
            _position.X -= 1;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("You hit a wall.");
            Console.ReadKey();
        }
    }
    public void MoveEast()
    {
        if (Map.IsValidPosition(Position.X, Position.Y + 1))
        {
            _position.Y += 1;
        }
         else
        {
            Console.Clear();
            Console.WriteLine("You hit a wall.");
            Console.ReadKey();
        }
    }
    public void MoveWest()
    {
        if (Map.IsValidPosition(Position.X, Position.Y - 1))
        {
            _position.Y -= 1;
        }
         else
        {
            Console.Clear();
            Console.WriteLine("You hit a wall.");
            Console.ReadKey();
        }
    }
}


public class PlayerInput
{
    private Player _player;
    IPlayerCommand? playerCommand;
    public PlayerInput(Player player)
    {
        _player = player;
    }

    public void Update(string userInput)
    {
        
        switch (userInput)
        {
            case "move north":
                playerCommand = new MoveCommand(_player, Direction.North);
                break;
            case "move south":
                playerCommand = new MoveCommand(_player, Direction.South);
                break;
            case "move east":
                playerCommand = new MoveCommand(_player, Direction.East);
                break;
            case "move west":
                playerCommand = new MoveCommand(_player, Direction.West);
                break;
            case "activate fountain":
                playerCommand = new EnableFountainCommand();
                break;
            default:
                break;
        }
        playerCommand?.ExecuteCommand();
    }
}

public interface IPlayerCommand
{
    public void ExecuteCommand();
}
public class MoveCommand : IPlayerCommand
{
    private Player _player;
    private Direction _direction;
    public MoveCommand(Player player, Direction direction)
    {
        _player = player;
        _direction = direction;
    }

    public void ExecuteCommand()
    {
        switch (_direction)
        {
            case Direction.North:
                _player.MoveNorth();
                break;
            case Direction.South:
                _player.MoveSouth();
                break;
            case Direction.East:
                _player.MoveEast();
                break;
            case Direction.West:
                _player.MoveWest();
                break;
            default:
                break;
        }
    }
}
public class EnableFountainCommand : IPlayerCommand
{
    public void ExecuteCommand()
    {
        Game.Instance.EnableFountain();
/*        if (Game.Instance._map.RoomArray[Game.Instance._player.Position.X, Game.Instance_player.Position.Y].RoomType == RoomType.Fountain)
        {
            Game.Instance._isFountainActive = true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("The Fountain Of Objects is not in this room.");
            Console.ReadKey();
        }*/
    }
}
public struct Position { public int X, Y; }
public enum RoomType { Entrance, Fountain, Empty, Wall }
public enum Direction { North, South, East, West}
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
    
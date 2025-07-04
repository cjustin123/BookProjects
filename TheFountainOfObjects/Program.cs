﻿using System.Runtime.CompilerServices;
using System;
using System.ComponentModel;

Console.Clear();
Game _game;
_game = new Game();

_game.Run();


public class Game
{
    const int SMALL = 3;
    const int MEDIUM = 4;
    const int LARGE = 5;

    Map _map;
    Player _player = new Player();
    PlayerInput? _playerInput;
    bool _isFountainActive = false;
    public bool IsFountainActive { get => _isFountainActive; }
    public static Game Instance;

    public Game()
    {
        Console.WriteLine("small, medium, large?");
        string selection = Console.ReadLine();
        switch (selection.ToLower())
        {
            case "small":
                _map = new Map(SMALL);
                break;
            case "medium":
                _map = new Map(MEDIUM);
                break;
            case "large":
                _map = new Map(LARGE);
                break;
            default:
                _map = new Map(MEDIUM);
                break;

        }
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
            Console.Clear();
            // Player checks senses of current room
            Console.WriteLine($"Current Position: ({_player.Position.X}, {_player.Position.Y})");// UI class method
            Console.WriteLine($"Room: {_map.RoomArray[_player.Position.X, _player.Position.Y].RoomType}");
            _player.UpdateSenses();
            if (_isFountainActive)
            {
                Console.WriteLine("Objective Achieved!");
            }
            _map.DisplayMap(_player.Position);
            //Process player input
            string playerInput = Console.ReadLine();
            _playerInput.Update(playerInput.ToLower());
        }
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
    public void UpdateSenses()
    {
        switch(Map.RoomArray[Position.X,Position.Y].RoomType)
        {
            case RoomType.Entrance:
                Console.WriteLine("You can see the light from outside. This must be the entrance.");
                break;
            case RoomType.Fountain:
                if (Game.Instance.IsFountainActive)
                {
                    Console.WriteLine("You hear the rushing waters of The Founatin of Objects. The Fountain has been activated!");
                }
                else
                {
                    Console.WriteLine("You hear something dripping. This must be where The Fountain of Objects is.");
                }
                break;
            default:
                Console.WriteLine("Advanced darkness.");
                break;
        }
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
                playerCommand = null;
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
    }
}
public struct Position { public int X, Y; }
public enum RoomType { Entrance, Fountain, Empty, Wall, Pit }
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
    public int Size { get; private set; }

    public Room[,] RoomArray;
    public Map(int size)
    {
        Size = size;
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
    
    public void BuildLevel()
    {
        // fountain placement
        Random rnd = new Random();
        int fountainX = rnd.Next(1, Size);
        int fountainY = rnd.Next(1, Size);
        Position fountainPosition = new Position();
        fountainPosition.X = fountainX;
        fountainPosition.Y = fountainY;

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
                else if (rnd.Next(1, 4) == 1) // WTF!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                {
                    newRoom.SetRoomType(RoomType.Pit);
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
    
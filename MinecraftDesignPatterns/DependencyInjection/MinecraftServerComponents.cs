using System;

namespace MinecraftDesignPatterns.DependencyInjection;

public interface ILoggerService { void Log(string message); }
public class ConsoleLoggerService : ILoggerService
{
    public void Log(string message) => Console.WriteLine($"[LOG] [{DateTime.Now:HH:mm:ss}] {message}");
}

public interface IDatabaseService { void SaveData(string key, string value); }
public class MinecraftDatabaseService : IDatabaseService
{
    public void SaveData(string key, string value) => Console.WriteLine($"[DB] Дані збережено: {key} -> {value}");
}

public interface IConfigService { string GetServerProperty(string key); }
public class ServerConfigService : IConfigService
{
    public string GetServerProperty(string key) => key == "MaxPlayers" ? "20" : "Survival";
}

public interface IPlayerRegistry { void Register(string username); }
public class PlayerRegistry : IPlayerRegistry
{
    private readonly ILoggerService _logger; 

    public PlayerRegistry(ILoggerService logger)
    {
        _logger = logger;
    }

    public void Register(string username)
    {
        _logger.Log($"Реєстрація нового гравця на сервері: {username}");
    }
}

public interface IWorldManager { void GenerateSpawn(); }
public class WorldManager : IWorldManager
{
    private readonly IDatabaseService _database; 
    private readonly IConfigService _config;     

    public WorldManager(IDatabaseService database, IConfigService config)
    {
        _database = database;
        _config = config;
    }

    public void GenerateSpawn()
    {
        string mode = _config.GetServerProperty("GameMode");
        Console.WriteLine($"[Світ] Генерація спавну для режиму: {mode}");
        _database.SaveData("Spawnpoint", "X:0, Y:64, Z:0");
    }
}

public interface IMinecraftServer { void Start(); }
public class MinecraftServer : IMinecraftServer
{
    private readonly ILoggerService _logger;      
    private readonly IPlayerRegistry _playerRegistry; 
    private readonly IWorldManager _worldManager;  

    public MinecraftServer(ILoggerService logger, IPlayerRegistry playerRegistry, IWorldManager worldManager)
    {
        _logger = logger;
        _playerRegistry = playerRegistry;
        _worldManager = worldManager;
    }

    public void Start()
    {
        _logger.Log("Ініціалізація ядра сервера Minecraft...");
        _worldManager.GenerateSpawn();
        _playerRegistry.Register("LinaBodnar");
        _logger.Log("Сервер успішно запущено на порту 25565! Очікування гравців...");
    }
}
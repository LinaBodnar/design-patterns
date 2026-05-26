namespace MinecraftDesignPatterns.Structural.Proxy;

public interface IGameServer { void ConnectPlayer(string username); }

public class RealMinecraftServer : IGameServer
{
    public void ConnectPlayer(string username) => Console.WriteLine($"[Server] Гравець {username} успішно зайшов у гру!");
}

public class ServerProxy : IGameServer
{
    private readonly RealMinecraftServer _realServer = new RealMinecraftServer();
    private readonly List<string> _bannedPlayers = new List<string> { "Griefer777", "CheaterNet" };

    public void ConnectPlayer(string username)
    {
        Console.WriteLine($"[Proxy] Перевірка безпеки для гравця: {username}");
        if (_bannedPlayers.Contains(username))
        {
            Console.WriteLine($"[Proxy] ВІДХИЛЕНО: Гравець {username} забанений на цьому сервері!");
        }
        else
        {
            _realServer.ConnectPlayer(username);
        }
    }
}
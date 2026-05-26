namespace MinecraftDesignPatterns.Creational.Singleton;

public class WorldRegistry 
{
    private static WorldRegistry _instance;
    public string WorldName { get; set; } = "Світ Лінки";
    
    private WorldRegistry() {}
    
    public static WorldRegistry GetInstance() 
    {
        if (_instance == null) _instance = new WorldRegistry();
        return _instance;
    }
}
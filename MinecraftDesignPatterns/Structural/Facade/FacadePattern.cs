namespace MinecraftDesignPatterns.Structural.Facade;

public class AudioSubsystem { public void Init() => Console.WriteLine("Завантаження звуків кроків та ембієнту..."); }
public class RenderSubsystem { public void Init() => Console.WriteLine("Ініціалізація OpenGL / Рендеру світу..."); }
public class NetworkSubsystem { public void Init() => Console.WriteLine("Підключення до серійного серверу Mojang..."); }

public class MinecraftGameFacade
{
    private readonly AudioSubsystem _audio = new AudioSubsystem();
    private readonly RenderSubsystem _render = new RenderSubsystem();
    private readonly NetworkSubsystem _network = new NetworkSubsystem();

    public void StartGame()
    {
        Console.WriteLine("[Facade] Запуск Minecraft однією кнопкою...");
        _audio.Init();
        _render.Init();
        _network.Init();
        Console.WriteLine("[Facade] Гра успішно запущена! Світ готовий.");
    }
}
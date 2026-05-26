namespace MinecraftDesignPatterns.Structural.Bridge;

public interface IPlatform { void RenderGraphics(); }
public class PcPlatform : IPlatform { public void RenderGraphics() => Console.WriteLine("Рендеринг на ПК з трасуванням променів (RTX On)."); }
public class MobilePlatform : IPlatform { public void RenderGraphics() => Console.WriteLine("Рендеринг на телефоні в енергоощадному режимі."); }

public abstract class GameMod
{
    protected IPlatform platform;
    protected GameMod(IPlatform platform) => this.platform = platform;
    public abstract void ApplyMod();
}

public class PhysicsMod : GameMod
{
    public PhysicsMod(IPlatform platform) : base(platform) {}
    public override void ApplyMod()
    {
        Console.Write("[Bridge] Мод на реалістичну фізику активовано: ");
        platform.RenderGraphics();
    }
}
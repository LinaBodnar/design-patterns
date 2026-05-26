namespace MinecraftDesignPatterns.Creational.Prototype;

public interface IBlockPrototype { IBlockPrototype Clone(); void ShowColor(); }

public class Sheep : IBlockPrototype 
{
    public string Color { get; set; }
    public Sheep(string color) { Color = color; }
    public IBlockPrototype Clone() => new Sheep(this.Color);
    public void ShowColor() => Console.WriteLine($"[Prototype] Вівця, колір: {Color}");
}
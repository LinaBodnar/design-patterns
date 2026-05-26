namespace MinecraftDesignPatterns.Structural.Composite;

public interface IWorldElement { void Display(string indent); }

public class Block : IWorldElement
{
    private readonly string _name;
    public Block(string name) => _name = name;
    public void Display(string indent) => Console.WriteLine($"{indent} Блок: {_name}");
}

public class StructureComposite : IWorldElement
{
    private readonly string _name;
    private readonly List<IWorldElement> _elements = new List<IWorldElement>();

    public StructureComposite(string name) => _name = name;
    public void Add(IWorldElement element) => _elements.Add(element);

    public void Display(string indent)
    {
        Console.WriteLine($"{indent}+ Структура: {_name}");
        foreach (var element in _elements)
        {
            element.Display(indent + "  ");
        }
    }
}
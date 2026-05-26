namespace MinecraftDesignPatterns.Structural.Flyweight;

public class BlockTypeFlyweight
{
    public string Name { get; private set; }
    public string TextureData { get; private set; }

    public BlockTypeFlyweight(string name, string texture)
    {
        Name = name;
        TextureData = texture;
    }

    public void Render(int x, int y, int z)
    {
        Console.WriteLine($"[Flyweight] Рендер блоку '{Name}' на колінах ({x}, {y}, {z}) використовуючи спільну текстуру: {TextureData}");
    }
}

public class BlockTypeFactory
{
    private readonly Dictionary<string, BlockTypeFlyweight> _types = new Dictionary<string, BlockTypeFlyweight>();

    public BlockTypeFlyweight GetBlockType(string name, string texture)
    {
        if (!_types.ContainsKey(name))
        {
            _types[name] = new BlockTypeFlyweight(name, texture);
        }
        return _types[name];
    }
}
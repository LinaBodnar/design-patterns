namespace MinecraftDesignPatterns.Creational.Builder;

public class House 
{
    public string Walls { get; set; } = "Земля";
    public string Roof { get; set; } = "Немає";
    public bool HasWindows { get; set; }
    public void Show() => Console.WriteLine($"[Builder] Збудовано будинок: стіни з {Walls}, дах з {Roof}, вікна: {HasWindows}");
}

public class HouseBuilder 
{
    private House _house = new House();
    public HouseBuilder BuildWalls(string material) { _house.Walls = material; return this; }
    public HouseBuilder BuildRoof(string material) { _house.Roof = material; return this; }
    public HouseBuilder AddWindows() { _house.HasWindows = true; return this; }
    public House Build() => _house;
}
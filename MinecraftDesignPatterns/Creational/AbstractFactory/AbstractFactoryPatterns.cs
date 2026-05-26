namespace MinecraftDesignPatterns.Creational.AbstractFactory;

public interface IBlock { void Info(); }
public interface IMob { void Spawn(); }

public class SandBlock : IBlock { public void Info() => Console.WriteLine("[Abstract Factory] Блок піску"); }
public class Zombie : IMob { public void Spawn() => Console.WriteLine("[Abstract Factory] Зомбі заспавнився в пустелі!"); }

public interface IBiomeFactory { IBlock CreateBlock(); IMob CreateMob(); }
public class DesertFactory : IBiomeFactory 
{
    public IBlock CreateBlock() => new SandBlock();
    public IMob CreateMob() => new Zombie();
}
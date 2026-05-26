using MinecraftDesignPatterns.Behavioral.Visitor;

namespace MinecraftDesignPatterns.Creational.AbstractFactory;

public interface IBlock { void Info(); }
public interface IMob { void Spawn();
    void Accept(IMobVisitor potion);
}

public class SandBlock : IBlock { public void Info() => Console.WriteLine("[Abstract Factory] Блок піску"); }
public class Zombie : IMob {
    private IMob _mobImplementation;
    public void Spawn() => Console.WriteLine("[Abstract Factory] Зомбі заспавнився в пустелі!");
    public void Accept(IMobVisitor visitor)
    {
        // Тепер зомбі правильно приймає відвідувача-зілля
        visitor.VisitZombie(this); 
    }
}

public interface IBiomeFactory { IBlock CreateBlock(); IMob CreateMob(); }
public class DesertFactory : IBiomeFactory 
{
    public IBlock CreateBlock() => new SandBlock();
    public IMob CreateMob() => new Zombie();
}
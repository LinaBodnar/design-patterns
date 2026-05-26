using System;
using MinecraftDesignPatterns.Creational.AbstractFactory;

namespace MinecraftDesignPatterns.Behavioral.Visitor;

public interface IMob { void Accept(IMobVisitor visitor); }

public class Creeper : IMob, Creational.AbstractFactory.IMob
{
    public void Spawn() => Console.WriteLine("[Abstract Factory] Кріпер заспавнився у темній печері!");

    public void Accept(IMobVisitor visitor) => visitor.VisitCreeper(this);
}

public interface IMobVisitor
{
    void VisitCreeper(Creeper creeper);
    void VisitZombie(Zombie zombie);
}

public class SplashPotionOfHealing : IMobVisitor
{
    public void VisitCreeper(Creeper creeper) => 
        Console.WriteLine("[Visitor] Зілля зцілення кинуто в Кріпера! (Він отримав шкоду, бо він ворожий моб)");

    public void VisitZombie(Zombie zombie) => 
        Console.WriteLine("[Visitor] Зілля зцілення кинуто в Зомбі! (Він отримав шкоду, бо він ворожий моб)");
}
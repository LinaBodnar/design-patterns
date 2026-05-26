using System;

namespace MinecraftDesignPatterns.Behavioral.Strategy;

public interface IMovementStrategy { void Move(); }

public class WalkStrategy : IMovementStrategy { public void Move() => Console.WriteLine("[Strategy] Гравець повільно йде пішки."); }
public class ElytraStrategy : IMovementStrategy { public void Move() => Console.WriteLine("[Strategy] Епічний політ на елітрах за допомогою феєрверків!"); }

public class PlayerMovementContext
{
    private IMovementStrategy _strategy = new WalkStrategy();
    public void SetStrategy(IMovementStrategy strategy) => _strategy = strategy;
    public void ExecuteMove() => _strategy.Move();
}
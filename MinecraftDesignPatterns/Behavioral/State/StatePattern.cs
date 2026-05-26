using System;

namespace MinecraftDesignPatterns.Behavioral.State;

public interface IWolfState { void HandleBehavior(); }

public class WildState : IWolfState
{
    public void HandleBehavior() => Console.WriteLine("[State] Вовк гарчить і блукає лісом у пошуках овець.");
}

public class TamedState : IWolfState
{
    public void HandleBehavior() => Console.WriteLine("[State] Вовк махає хвостом і сидить поруч із господарем.");
}

public class WolfContext
{
    public IWolfState State { get; set; } = new WildState();
    public void Update() => State.HandleBehavior();
}
using System;
using System.Collections.Generic;

namespace MinecraftDesignPatterns.Behavioral.Observer;

public interface IGameObserver { void OnEvent(string gameEvent); }

public class AchievementSystem : IGameObserver
{
    public void OnEvent(string gameEvent)
    {
        if (gameEvent == "DIAMOND_MINED")
            Console.WriteLine("[Observer] АЧІВКА: 'Diamonds!' успішно розблокована!");
    }
}

public class EventRegistry
{
    private readonly List<IGameObserver> _observers = new();
    public void Subscribe(IGameObserver obs) => _observers.Add(obs);
    public void TriggerEvent(string e) => _observers.ForEach(o => o.OnEvent(e));
}
using System;

namespace MinecraftDesignPatterns.Behavioral.Memento;

public class PlayerStateMemento
{
    public int Health { get; }
    public string Inventory { get; }
    public PlayerStateMemento(int hp, string inv) { Health = hp; Inventory = inv; }
}

public class PlayerOriginator
{
    public int Health { get; set; } = 20;
    public string Inventory { get; set; } = "Пусто";

    public PlayerStateMemento Save() => new(Health, Inventory);
    public void Restore(PlayerStateMemento memento)
    {
        Health = memento.Health;
        Inventory = memento.Inventory;
    }
}
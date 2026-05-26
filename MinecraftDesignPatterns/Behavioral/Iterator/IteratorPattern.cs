using System;
using System.Collections.Generic;

namespace MinecraftDesignPatterns.Behavioral.Iterator;

public class ChestAggregate
{
    private readonly List<string> _slots = new() { "Алмаз", "Кругляк", "Яблуко", "Залізо" };
    public int Count => _slots.Count;
    public string this[int index] => _slots[index];
}

public class ChestIterator
{
    private readonly ChestAggregate _chest;
    private int _current;

    public ChestIterator(ChestAggregate chest) => _chest = chest;
    public bool HasNext() => _current < _chest.Count;
    public string Next() => _chest[_current++];
}
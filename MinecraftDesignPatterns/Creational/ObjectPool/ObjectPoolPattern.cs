using System.Collections.Generic;

namespace MinecraftDesignPatterns.Creational.ObjectPool;

public class Arrow { public bool IsActive { get; set; } = false; }

public class ArrowPool 
{
    private List<Arrow> _pool = new List<Arrow>();

    public Arrow GetArrow() 
    {
        foreach (var arrow in _pool) 
        {
            if (!arrow.IsActive) 
            {
                arrow.IsActive = true;
                return arrow;
            }
        }
        var newArrow = new Arrow { IsActive = true };
        _pool.Add(newArrow);
        return newArrow;
    }

    public void ReturnArrow(Arrow arrow) { arrow.IsActive = false; }
    public int GetTotalCount() => _pool.Count;
}
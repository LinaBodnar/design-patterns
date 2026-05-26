using System;

namespace MinecraftDesignPatterns.Behavioral.TemplateMethod;

public abstract class SmeltingProcess
{
    public void Smelt() 
    {
        PutFuel();
        WaitSmelting();
        GiveResult();
    }
    protected void PutFuel() => Console.WriteLine("[Template] Додано вугілля у піч.");
    protected abstract void WaitSmelting();
    protected abstract void GiveResult();
}

public class IronSmelting : SmeltingProcess
{
    protected override void WaitSmelting() => Console.WriteLine("[Template] Залізна руда плавиться...");
    protected override void GiveResult() => Console.WriteLine("[Template] Отримано залізний злиток!");
}
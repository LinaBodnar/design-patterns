using System;
using MinecraftDesignPatterns.Creational.FactoryMethod;
using MinecraftDesignPatterns.Creational.AbstractFactory;
using MinecraftDesignPatterns.Creational.Builder;
using MinecraftDesignPatterns.Creational.Prototype;
using MinecraftDesignPatterns.Creational.Singleton;
using MinecraftDesignPatterns.Creational.ObjectPool;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Лаба 1: породжувальні патерни\n");

Console.WriteLine("1. Тестуємо Factory Method");
ToolFactory toolFactory = new DiamondFactory();
Tool pickaxe = toolFactory.CreateTool();
pickaxe.Use();
Console.WriteLine();

Console.WriteLine("2. Тестуємо Abstract Factory");
IBiomeFactory biome = new DesertFactory();
biome.CreateBlock().Info();
biome.CreateMob().Spawn();
Console.WriteLine();

Console.WriteLine("3. Тестуємо Builder");
var house = new HouseBuilder()
    .BuildWalls("Дубові дошки")
    .BuildRoof("Сланцева черепиця")
    .AddWindows()
    .Build();
house.Show();
Console.WriteLine();

Console.WriteLine("4. Тестуємо Prototype");
Sheep originalWhiteSheep = new Sheep("Білий");
Sheep clonedSheep = (Sheep)originalWhiteSheep.Clone();
clonedSheep.Color = "Рожевий"; 
originalWhiteSheep.ShowColor();
clonedSheep.ShowColor();
Console.WriteLine();

Console.WriteLine("5. Тестуємо Singleton");
WorldRegistry world1 = WorldRegistry.GetInstance();
WorldRegistry world2 = WorldRegistry.GetInstance();
Console.WriteLine($"Назва світу 1: {world1.WorldName}");
Console.WriteLine($"Чи це один і той самий об'єкт? {ReferenceEquals(world1, world2)}");
Console.WriteLine();

Console.WriteLine("6. Тестуємо Object Pool");
ArrowPool pool = new ArrowPool();
Arrow a1 = pool.GetArrow();
Console.WriteLine($"Стріла 1 активована. Всього об'єктів в пулі: {pool.GetTotalCount()}");
pool.ReturnArrow(a1); 

Arrow a2 = pool.GetArrow(); 
Console.WriteLine($"Стріла 2 активована. Всього об'єктів в пулі: {pool.GetTotalCount()} (Об'єкт було перевикористано!)");
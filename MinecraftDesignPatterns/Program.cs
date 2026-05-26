using System;
using MinecraftDesignPatterns.Creational.FactoryMethod;
using MinecraftDesignPatterns.Creational.AbstractFactory;
using MinecraftDesignPatterns.Creational.Builder;
using MinecraftDesignPatterns.Creational.Prototype;
using MinecraftDesignPatterns.Creational.Singleton;
using MinecraftDesignPatterns.Creational.ObjectPool;

using MinecraftDesignPatterns.Structural.Adapter;
using MinecraftDesignPatterns.Structural.Bridge;
using MinecraftDesignPatterns.Structural.Composite;
using MinecraftDesignPatterns.Structural.Decorator;
using MinecraftDesignPatterns.Structural.Facade;
using MinecraftDesignPatterns.Structural.Flyweight;
using MinecraftDesignPatterns.Structural.Proxy;

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



Console.WriteLine("Лаба 2: структурні патерни\n");

Console.WriteLine("\n--- 1. Тестуємо Adapter ---");
INewSaveSystem saveSystem = new SaveSystemAdapter();
saveSystem.SavePlayerData("Steve", "X:100, Y:64, Z:-250");

Console.WriteLine("\n--- 2. Тестуємо Bridge ---");
GameMod physicsOnPc = new PhysicsMod(new PcPlatform());
physicsOnPc.ApplyMod();
GameMod physicsOnMobile = new PhysicsMod(new MobilePlatform());
physicsOnMobile.ApplyMod();

Console.WriteLine("\n--- 3. Тестуємо Composite ---");
var rootHouse = new StructureComposite("Budynok Gravtsya");
var walls = new StructureComposite("Stiny z kruglyaka");
walls.Add(new Block("Blok kruglyaka"));
walls.Add(new Block("Blok kruglyaka z mohom"));

rootHouse.Add(walls);
rootHouse.Add(new Block("Sklyana panel (vikno)"));
rootHouse.Add(new Block("Dubovi dveri"));

rootHouse.Display("");

Console.WriteLine("\n--- 4. Тестуємо Decorator ---");
IWeapon basicSword = new DiamondSword();
Console.WriteLine($"Базова зброя: {basicSword.GetDescription()}, Шкода: {basicSword.GetDamage()}");

IWeapon enchantedSword = new FireAspectDecorator(basicSword);
Console.WriteLine($"Зачарована зброя: {enchantedSword.GetDescription()}, Шкода: {enchantedSword.GetDamage()}");

Console.WriteLine("\n--- 5. Тестуємо Facade ---");
MinecraftGameFacade gameLauncher = new MinecraftGameFacade();
gameLauncher.StartGame();

Console.WriteLine("\n--- 6. Тестуємо Flyweight ---");
BlockTypeFactory typeFactory = new BlockTypeFactory();
var grassType = typeFactory.GetBlockType("Трава", "grass_texture_HD_4K.png");

grassType.Render(0, 64, 0);
grassType.Render(0, 64, 1);
grassType.Render(1, 64, 0);

Console.WriteLine("\n--- 7. Тестуємо Proxy ---");
IGameServer server = new ServerProxy();
server.ConnectPlayer("bisizbee");
server.ConnectPlayer("vjigfnv");
server.ConnectPlayer("Griefer777");
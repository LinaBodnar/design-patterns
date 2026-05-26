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

using MinecraftDesignPatterns.Behavioral.ChainOfResponsibility;
using MinecraftDesignPatterns.Behavioral.Command;
using MinecraftDesignPatterns.Behavioral.Iterator;
using MinecraftDesignPatterns.Behavioral.Mediator;
using MinecraftDesignPatterns.Behavioral.Memento;
using MinecraftDesignPatterns.Behavioral.Observer;
using MinecraftDesignPatterns.Behavioral.State;
using MinecraftDesignPatterns.Behavioral.Strategy;
using MinecraftDesignPatterns.Behavioral.TemplateMethod;
using MinecraftDesignPatterns.Behavioral.Visitor;
using IMob = MinecraftDesignPatterns.Creational.AbstractFactory.IMob;

using System.Collections.Generic;
using MinecraftDesignPatterns.LambdaExpression;

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

Console.WriteLine("\n1. Тестуємо Adapter");
INewSaveSystem saveSystem = new SaveSystemAdapter();
saveSystem.SavePlayerData("Steve", "X:100, Y:64, Z:-250");

Console.WriteLine("\n2. Тестуємо Bridge");
GameMod physicsOnPc = new PhysicsMod(new PcPlatform());
physicsOnPc.ApplyMod();
GameMod physicsOnMobile = new PhysicsMod(new MobilePlatform());
physicsOnMobile.ApplyMod();

Console.WriteLine("\n3. Тестуємо Composite");
var rootHouse = new StructureComposite("Будинок гравця");
var walls = new StructureComposite("Стіни з кругляка");
walls.Add(new Block("Блок кругляка"));
walls.Add(new Block("Блок кругляка з мохом"));

rootHouse.Add(walls);
rootHouse.Add(new Block("Скляна панель (вікно)"));
rootHouse.Add(new Block("Дубові двері"));

rootHouse.Display("");

Console.WriteLine("\n4. Тестуємо Decorator");
IWeapon basicSword = new DiamondSword();
Console.WriteLine($"Базова зброя: {basicSword.GetDescription()}, Шкода: {basicSword.GetDamage()}");

IWeapon enchantedSword = new FireAspectDecorator(basicSword);
Console.WriteLine($"Зачарована зброя: {enchantedSword.GetDescription()}, Шкода: {enchantedSword.GetDamage()}");

Console.WriteLine("\n5. Тестуємо Facade");
MinecraftGameFacade gameLauncher = new MinecraftGameFacade();
gameLauncher.StartGame();

Console.WriteLine("\n6. Тестуємо Flyweight");
BlockTypeFactory typeFactory = new BlockTypeFactory();
var grassType = typeFactory.GetBlockType("Трава", "grass_texture_HD_4K.png");

grassType.Render(0, 64, 0);
grassType.Render(0, 64, 1);
grassType.Render(1, 64, 0);

Console.WriteLine("\n7. Тестуємо Proxy");
IGameServer server = new ServerProxy();
server.ConnectPlayer("bisizbee");
server.ConnectPlayer("vjigfnv");
server.ConnectPlayer("Griefer777");


Console.WriteLine("Лаба 3: поведінкові патерни\n");

Console.WriteLine("\n1. Chain of Responsibility");
var mod = new ModeratorHandler();
var admin = new AdminHandler();
mod.SetSuccessor(admin);
mod.HandleRequest("/mute", "MODERATOR");
mod.HandleRequest("/ban", "ADMIN");

Console.WriteLine("\n2. Command");
var player = new PlayerReceiver();
ICommand jump = new JumpCommand(player);
jump.Execute();

Console.WriteLine("\n3. Iterator");
var chest = new ChestAggregate();
var it = new ChestIterator(chest);
Console.Write("Вміст скрині: ");
while (it.HasNext()) { Console.Write($"[{it.Next()}] "); }
Console.WriteLine();

Console.WriteLine("\n4. Mediator");
var chat = new ServerChatMediator();
var alex = new PlayerElement("Alex", chat);
var notch = new PlayerElement("Notch", chat);
alex.Send("Привіт усім!");
notch.Send("Вітаю у світі Minecraft!");

Console.WriteLine("\n5. Memento");
var steve = new PlayerOriginator { Health = 20, Inventory = "Алмазна кирка" };
Console.WriteLine($"Поточний стан: HP={steve.Health}, Предмети={steve.Inventory}");
var backup = steve.Save(); 

steve.Health = 2; steve.Inventory = "Кругляк (Впав у лаву!)";
Console.WriteLine($"Стан після катастрофи: HP={steve.Health}, Предмети={steve.Inventory}");
steve.Restore(backup); 
Console.WriteLine($"Стан після завантаження бекапу: HP={steve.Health}, Предмети={steve.Inventory}");

Console.WriteLine("\n6. Observer");
var registry = new EventRegistry();
registry.Subscribe(new AchievementSystem());
registry.TriggerEvent("DIAMOND_MINED");

Console.WriteLine("\n7. State");
var wolf = new WolfContext();
wolf.Update();
wolf.State = new TamedState();
wolf.Update();

Console.WriteLine("\n8. Strategy");
var moveContext = new PlayerMovementContext();
moveContext.ExecuteMove();
moveContext.SetStrategy(new ElytraStrategy());
moveContext.ExecuteMove();

Console.WriteLine("\n9. Template Method");
SmeltingProcess furnace = new IronSmelting();
furnace.Smelt();

Console.WriteLine("\n10. Visitor");
IMob greenCreeper = new Creeper();
IMobVisitor potion = new SplashPotionOfHealing();
greenCreeper.Accept(potion);


Console.WriteLine("Лаба 4: лямбда-вирази\n");

List<int> numbers = new List<int> { 4, 7, 2, 9, 12, 5, 2, 14, 11 };
List<double> doubleNumbers = new List<double> { 1.5, 3.5, 5.0, 2.0 };
List<string> wordsList = new List<string> { "Apple", "Banana", "Orange", "Kiwi", "Grape" };
List<string> mixedStrings = new List<string> { "", "", "CSharp", "Lambda", "Parallel" };
List<string> upperCaseStrings = new List<string> { "Hello", "World", "Developer" };

Console.WriteLine($"1. Непарні числа зі списку: {string.Join(", ", LambdaTasks.FilterOddNumbers(numbers))}");

Console.WriteLine($"2. Середнє значення дійсних чисел: {LambdaTasks.FindAverage(doubleNumbers)}");

Console.WriteLine($"3. Сортування в алфавітному порядку: {string.Join(", ", LambdaTasks.SortAlphabetically(wordsList))}");

Console.WriteLine($"4. Сума всіх парних чисел: {LambdaTasks.SumOfEvenNumbers(numbers)}");

int n = 6;
Console.WriteLine($"5. Факторіал числа {n}: {LambdaTasks.CalculateFactorial(n)}");

List<int> simpleList = new List<int> { 1, 2, 3, 4, 5 };
var (mult, sum) = LambdaTasks.MultiplyAndSum(simpleList);
Console.WriteLine($"6. Для списку (1, 2, 3, 4, 5): Добуток = {mult}, Сума = {sum}");

Console.WriteLine($"7. Квадрати чисел списку (1..5): {string.Join(", ", LambdaTasks.SquareNumbers(simpleList))}");

Console.WriteLine($"8. Сортування за довжиною рядків: {string.Join(", ", LambdaTasks.SortByLength(wordsList))}");

string text = "Лямбда вирази та інструменти LINQ працюють дуже ефективно";
Console.WriteLine($"9. Кількість слів у реченні: {LambdaTasks.CountWords(text)}");

Console.WriteLine($"10. Перший непорожній рядок у списку: '{LambdaTasks.FindFirstNonEmptyString(mixedStrings)}'");

Console.WriteLine($"11. Чи всі рядки починаються з великої літери? Список 1: {LambdaTasks.AreAllStartingWithUpperCase(upperCaseStrings)}, Список 2: {LambdaTasks.AreAllStartingWithUpperCase(mixedStrings)}");

Console.WriteLine($"12. Друге за величиною число у списку: {LambdaTasks.FindSecondLargest(numbers)}");

Console.WriteLine($"13. Найбільше парне число у списку: {LambdaTasks.FindMaxEvenNumber(numbers)}");

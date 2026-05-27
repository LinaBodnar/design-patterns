using System;

namespace MinecraftDesignPatterns.FunctionalPatterns;

public static class FunctionalTasks
{
    public static void AttackMob(string mobName, Action<string> attackStrategy)
    {
        attackStrategy(mobName);
    }
    
    public static string CraftItem(Func<string> itemFactory)
    {
        return itemFactory();
    }
    
    public static Func<int, int> CreateEnchantedTool(Func<int, int> baseTool, string enchantmentName, int bonusDamage)
    {
        return (baseDamage) =>
        {
            // Викликаємо базову атаку
            int totalDamage = baseTool(baseDamage);
            Console.WriteLine($"[Декоратор] Накладено чари: {enchantmentName} (+{bonusDamage} до шкоди)");
            return totalDamage + bonusDamage;
        };
    }
    
    public static void UseChest(string chestType, Action chestOperations)
    {
        Console.WriteLine($"\n[Execute Around] >>> Гравець відкриває {chestType} скриню...");
        try
        {
            chestOperations();
        }
        finally
        {
            Console.WriteLine($"[Execute Around] <<< Скриню успішно закрито та збережено на сервері.");
        }
    }
}
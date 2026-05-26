namespace MinecraftDesignPatterns.Structural.Adapter;

public interface INewSaveSystem { void SavePlayerData(string nickname, string coordinates); }

public class OldSaveSystem 
{
    public string ConvertAndSerialize(string rawData) => $"[OLD SYSTEM SERIALIZED]: {rawData}";
}

public class SaveSystemAdapter : INewSaveSystem
{
    private readonly OldSaveSystem _oldSystem = new OldSaveSystem();

    public void SavePlayerData(string nickname, string coordinates)
    {
        string combined = $"Player:{nickname};Pos:{coordinates}";
        string result = _oldSystem.ConvertAndSerialize(combined);
        Console.WriteLine($"[Adapter] Дані збережено через адаптер: {result}");
    }
}
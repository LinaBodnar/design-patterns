using System;

namespace MinecraftDesignPatterns.Behavioral.ChainOfResponsibility;

public abstract class CommandHandler
{
    protected CommandHandler Successor;
    public void SetSuccessor(CommandHandler successor) => Successor = successor;
    public abstract void HandleRequest(string command, string playerRank);
}

public class ModeratorHandler : CommandHandler
{
    public override void HandleRequest(string command, string playerRank)
    {
        if (command == "/mute") 
            Console.WriteLine($"[Chain] Модератор обробив команду '{command}'");
        else Successor?.HandleRequest(command, playerRank);
    }
}

public class AdminHandler : CommandHandler
{
    public override void HandleRequest(string command, string playerRank)
    {
        if (command == "/ban") 
            Console.WriteLine($"[Chain] АДМІНІСТРАТОР обробив критичну команду '{command}'");
        else Successor?.HandleRequest(command, playerRank);
    }
}
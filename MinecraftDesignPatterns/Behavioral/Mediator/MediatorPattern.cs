using System;

namespace MinecraftDesignPatterns.Behavioral.Mediator;

public class ServerChatMediator
{
    public void SendMessage(string msg, string fromPlayer) => 
        Console.WriteLine($"[Chat Mediator] <{fromPlayer}>: {msg}");
}

public class PlayerElement
{
    private readonly ServerChatMediator _mediator;
    public string Name { get; }
    
    public PlayerElement(string name, ServerChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }
    public void Send(string msg) => _mediator.SendMessage(msg, Name);
}
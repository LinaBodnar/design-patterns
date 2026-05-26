using System;

namespace MinecraftDesignPatterns.Behavioral.Command;

public interface ICommand { void Execute(); }

public class PlayerReceiver
{
    public void Jump() => Console.WriteLine("[Command] Стів підстрибнув!");
}

public class JumpCommand : ICommand
{
    private readonly PlayerReceiver _player;
    public JumpCommand(PlayerReceiver player) => _player = player;
    public void Execute() => _player.Jump();
}
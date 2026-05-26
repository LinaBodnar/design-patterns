namespace MinecraftDesignPatterns.Creational.FactoryMethod;

public abstract class Tool 
{ 
    public abstract void Use(); 
}

public class WoodenPickaxe : Tool 
{ 
    public override void Use() => Console.WriteLine("Ламаємо камінь дерев'яною киркою..."); 
}

public class DiamondPickaxe : Tool 
{ 
    public override void Use() => Console.WriteLine("Епічно руйнуємо обсидіан алмазною киркою!"); 
}

public abstract class ToolFactory 
{ 
    public abstract Tool CreateTool(); 
}

public class WoodFactory : ToolFactory 
{ 
    public override Tool CreateTool() => new WoodenPickaxe(); 
}

public class DiamondFactory : ToolFactory 
{ 
    public override Tool CreateTool() => new DiamondPickaxe(); 
}
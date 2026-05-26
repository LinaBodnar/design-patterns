namespace MinecraftDesignPatterns.Structural.Decorator;

public interface IWeapon { string GetDescription(); int GetDamage(); }

public class DiamondSword : IWeapon
{
    public string GetDescription() => "Алмазний меч";
    public int GetDamage() => 7;
}

public abstract class EnchantmentDecorator : IWeapon
{
    protected IWeapon decoratedWeapon;
    protected EnchantmentDecorator(IWeapon weapon) => this.decoratedWeapon = weapon;
    public virtual string GetDescription() => decoratedWeapon.GetDescription();
    public virtual int GetDamage() => decoratedWeapon.GetDamage();
}

public class FireAspectDecorator : EnchantmentDecorator
{
    public FireAspectDecorator(IWeapon weapon) : base(weapon) {}
    public override string GetDescription() => base.GetDescription() + " + [Заговір вогню II]";
    public override int GetDamage() => base.GetDamage() + 4;
}
using StardewValley;

namespace CheatMenuMod.Cheats
{
  /// <summary>
  /// Add Money Cheat Class.
  /// </summary>
  public class AddMoney : Cheat
  {
    public override string Name { get; } = "Add Money";

    public override void Activate()
    {
      Game1.activeClickableMenu = new MoneyInputMenu(this);
    }

    /// <summary>
    /// Not needed for this cheat.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public override void Deactivate()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Add money to the player account.
    /// </summary>
    /// <param name="amountToAdd">Amount of money to add.</param>
    public void AddMoolah(int amountToAdd)
    {
      Game1.player.Money += amountToAdd;
    }
  }
}

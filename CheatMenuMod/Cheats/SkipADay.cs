using StardewValley;

namespace CheatMenuMod.Cheats
{
  /// <summary>
  /// Skip A Day Cheat Class.
  /// </summary>
  public class SkipADay : Cheat
  {
    public override string Name { get; } = "Skip A Day";

    public override void Activate()
    {
      Game1.newDay = true;
      Game1.fadeToBlackAlpha = 1f;
      Game1.fadeToBlack = true;
      Game1.warpFarmer("FarmHouse", 10, 10, false);
      Game1.timeOfDay = 600;
      Game1.player.mostRecentBed = new Microsoft.Xna.Framework.Vector2(10, 10);
    }

    public override void Deactivate()
    {
      throw new NotImplementedException();
    }
  }
}

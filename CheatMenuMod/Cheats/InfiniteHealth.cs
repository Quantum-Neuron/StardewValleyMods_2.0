﻿using StardewValley;

namespace CheatMenuMod.Cheats
{
  /// <summary>
  /// Infinite Health Cheat Class.
  /// </summary>
  public class InfiniteHealth : Cheat
  {
    public bool isActive;

    /// <summary>
    /// Apply the cheat name.
    /// </summary>
    public override string Name { get; } = "Infinite Health";

    /// <summary>
    /// Activate the cheat.
    /// </summary>
    public override void Activate()
    {
      isActive = true;
      Game1.player.health = Game1.player.maxHealth;
      Game1.addHUDMessage(new HUDMessage("Infinite Health Activated!", 1));
    }

    /// <summary>
    /// Disable the cheat.
    /// </summary>
    public override void Deactivate()
    {
      isActive = false;
      Game1.addHUDMessage(new HUDMessage("Infinite Health Deactivated!", 1));
    }

    /// <summary>
    /// Ensures that every game tick that the player's health is max.
    /// </summary>
    public void Update()
    {
      if (isActive)
      {
        Game1.player.health = Game1.player.maxHealth;
      }
    }
  }
}

namespace CheatMenuMod;

using global::CheatMenuMod.Cheats;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

/// <summary>
/// Cheat Menu Mod Entry Class
/// </summary>
public class CheatMenuMod : Mod
{
  private List<Cheat> cheats = new List<Cheat>();
  private InfiniteHealth? infiniteHealth;
  private AddMoney? addMoney;
  private SkipADay? skipADay;
  private MaxRelationship? maxRelationship;

  public override void Entry(IModHelper helper)
  {
    // Initialise the cheats.
    infiniteHealth = new InfiniteHealth();
    addMoney = new AddMoney();
    skipADay = new SkipADay();
    maxRelationship = new MaxRelationship(helper);
    cheats.Add(infiniteHealth);
    cheats.Add(addMoney);
    cheats.Add(skipADay);
    cheats.Add(maxRelationship);

    // Hook into the input events.
    helper.Events.Input.ButtonPressed += OnButtonPressed;
    helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
  }

  /// <summary>
  /// Handle the button pressed event.
  /// </summary>
  /// <param name="sender">The source of the event, typically the object that raised the event.</param>
  /// <param name="e">The event data containing information about the button press.</param>
  private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
  {
    if (e.Button == SButton.D1 &&
        (Helper.Input.IsDown(SButton.LeftControl) || Helper.Input.IsDown(SButton.RightControl)) &&
        (Helper.Input.IsDown(SButton.LeftShift) || Helper.Input.IsDown(SButton.RightShift)))
    {
      OpenCheatMenu();
    }
  }

  /// <summary>
  /// Open the cheat menu.
  /// </summary>
  private void OpenCheatMenu()
  {
    Game1.activeClickableMenu = new CheatMenu(this, cheats);
  }

  /// <summary>
  /// Handles the game update tick event to apply active cheats.
  /// </summary>
  /// <param name="sender">The source of the event, typically the object that raised the event.</param>
  /// <param name="e">The event data containing information about the update tick.</param>
  private void OnUpdateTicked(object? sender, UpdateTickedEventArgs e)
  {
    infiniteHealth?.Update();
  }
}

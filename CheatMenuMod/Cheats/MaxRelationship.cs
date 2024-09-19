using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace CheatMenuMod.Cheats
{
  public class MaxRelationship : Cheat
  {
    private readonly IModHelper helper;

    public MaxRelationship(IModHelper helper)
    {
      this.helper = helper;
    }

    public override string Name => "Max Relationship";

    public override void Activate()
    {
      helper.Events.Input.ButtonPressed += OnButtonPressed;
    }

    public override void Deactivate()
    {
      helper.Events.Input.ButtonPressed -= OnButtonPressed;
    }


    private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
    {
      if (e.Button == SButton.MouseLeft &&
          (helper.Input.IsDown(SButton.LeftShift) || helper.Input.IsDown(SButton.RightShift)))
      {
        var cursorPosition = helper.Input.GetCursorPosition().AbsolutePixels;
        var character = Game1.currentLocation.characters
          .FirstOrDefault(npc => npc.GetBoundingBox()
            .Contains((int)cursorPosition.X, (int)cursorPosition.Y));

        if (character != null)
        {
          Game1.player.friendshipData[character.Name] = new Friendship(2500);
          Game1.addHUDMessage(new HUDMessage($"Maxed relationship with {character.Name}!"));
        }
      }
    }
  }
}

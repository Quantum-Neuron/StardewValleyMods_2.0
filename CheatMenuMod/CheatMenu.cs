using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Menus;

namespace CheatMenuMod
{
  /// <summary>
  /// Cheat Menu Class.
  /// </summary>
  internal class CheatMenu : IClickableMenu
  {
    private readonly CheatMenuMod cheatMenuMod;
    private readonly List<Cheat> cheats;
    private readonly List<ClickableComponent> buttons;

    /// <summary>
    /// Initialise the cheat menu.
    /// </summary>
    /// <param name="cheatMenuMod"></param>
    /// <param name="cheats"></param>
    public CheatMenu(CheatMenuMod cheatMenuMod, List<Cheat> cheats) : base(Game1.viewport.Width / 2 - 200, Game1.viewport.Height / 2 - 200, 400, 400, true)
    {
      this.cheatMenuMod = cheatMenuMod;
      this.cheats = cheats;
      buttons = new List<ClickableComponent>();

      var yOffset = 100;

      foreach (var cheat in cheats)
      {
        buttons.Add(new ClickableComponent(new Rectangle(xPositionOnScreen + 100, yPositionOnScreen + yOffset, 200, 50), cheat.Name));
        yOffset += 60;
      }
    }

    /// <summary>
    /// Draw the cheat menu.
    /// </summary>
    /// <param name="spriteBatch">Sprite Batch.</param>
    public override void draw(SpriteBatch spriteBatch)
    {
      base.draw(spriteBatch);

      // Draw the background.
      drawTextureBox(spriteBatch, xPositionOnScreen, yPositionOnScreen, width, height, Color.White);

      //Draw the title.
      SpriteText.drawString(spriteBatch, "Cheat Menu", xPositionOnScreen + 100, yPositionOnScreen + 50);

      //Draw the buttons;
      foreach (var button in buttons)
      {
        drawTextureBox(spriteBatch, button.bounds.X, button.bounds.Y, button.bounds.Width, button.bounds.Height, Color.BlueViolet);
        SpriteText.drawString(spriteBatch, button.name, button.bounds.X + 100, button.bounds.Y + 25);
      }
    }

    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {
      // Handle menu clicks.
      base.receiveLeftClick(x, y, playSound);

      foreach (var button in buttons)
      {
        if (button.containsPoint(x, y))
        {
          cheats.First(cheat => cheat.Name == button.name)?.Activate();
        }
      }
    }
  }
}

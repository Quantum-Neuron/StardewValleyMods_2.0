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
    private ClickableComponent? hoveredButton;

    /// <summary>
    /// Initialise the cheat menu.
    /// </summary>
    /// <param name="cheatMenuMod"></param>
    /// <param name="cheats"></param>
    public CheatMenu(CheatMenuMod cheatMenuMod, List<Cheat> cheats)
        : base(Game1.viewport.Width / 2 - 200, Game1.viewport.Height / 2 - 200, 400, 400, true)
    {
      this.cheatMenuMod = cheatMenuMod;
      this.cheats = cheats;
      buttons = new List<ClickableComponent>();

      var yOffset = 100;

      foreach (var cheat in cheats)
      {
        // Adjust the size of the buttons to be smaller
        buttons.Add(new ClickableComponent(new Rectangle(xPositionOnScreen + 25, yPositionOnScreen + yOffset, 150, 40), cheat.Name));
        yOffset += 50; // Adjust the offset to prevent overlap
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

      // Draw the title.
      SpriteText.drawString(spriteBatch, "Cheat Menu", xPositionOnScreen + 100, yPositionOnScreen + 50);

      // Draw the buttons;
      foreach (var button in buttons)
      {
        Color buttonColor = button == hoveredButton ? Color.LightBlue : Color.BlueViolet;
        drawTextureBox(spriteBatch, button.bounds.X, button.bounds.Y, button.bounds.Width, button.bounds.Height, buttonColor);
        // Adjust the text position to prevent overlap
        SpriteText.drawString(spriteBatch, button.name, button.bounds.X + 10, button.bounds.Y + 10);
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

    public override void performHoverAction(int x, int y)
    {
      base.performHoverAction(x, y);

      hoveredButton = null;
      foreach (var button in buttons)
      {
        if (button.containsPoint(x, y))
        {
          hoveredButton = button;
          break;
        }
      }
    }
  }
}
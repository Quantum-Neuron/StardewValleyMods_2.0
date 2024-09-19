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
    private ClickableComponent closeButton;

    /// <summary>
    /// Initialise the cheat menu.
    /// </summary>
    /// <param name="cheatMenuMod"></param>
    /// <param name="cheats"></param>
    public CheatMenu(CheatMenuMod cheatMenuMod, List<Cheat> cheats)
        : base(Game1.viewport.Width / 2 - 200, Game1.viewport.Height / 2 - 200, 500, 500)
    {
      this.cheatMenuMod = cheatMenuMod;
      this.cheats = cheats;
      buttons = new List<ClickableComponent>();

      // Initialise the close button.
      closeButton = new ClickableComponent(new Rectangle(xPositionOnScreen + width - 50, yPositionOnScreen + 20, 40, 40), "Close");

      InitialiseButtons();
    }

    /// <summary>
    /// Initialises the buttons.
    /// </summary>
    private void InitialiseButtons()
    {
      buttons.Clear();
      var yOffset = 100;

      foreach (var cheat in cheats)
      {
        // Adjust the size of the buttons to be smaller
        buttons.Add(new ClickableComponent(new Rectangle(xPositionOnScreen + 25, yPositionOnScreen + yOffset, 40, 40), cheat.Name));
        yOffset += 100; // Adjust the offset to prevent overlap
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
      SpriteText.drawString(spriteBatch, "Cheat Menu", xPositionOnScreen + 100, yPositionOnScreen + 17);

      // Draw the buttons;
      foreach (var button in buttons)
      {
        Color buttonColor = button == hoveredButton ? Color.LightBlue : Color.BlueViolet;

        // Adjust the text position to prevent overlap
        SpriteText.drawString(spriteBatch, button.name, button.bounds.X, button.bounds.Y - 20);

        drawTextureBox(spriteBatch, button.bounds.X, button.bounds.Y + 20, button.bounds.Width, button.bounds.Height, buttonColor);
      }

      // Draw the close button.
      SpriteText.drawString(spriteBatch, "X", closeButton.bounds.X + 10, closeButton.bounds.Y + 10);

      // Draw the mouse on the Cheat Menu.
      drawMouse(spriteBatch);
    }

    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {
      // Handle menu clicks.
      base.receiveLeftClick(x, y, playSound);

      // Check if the close button was clicked.
      if (closeButton.containsPoint(x, y))
      {
        Game1.exitActiveMenu();
        return;
      }

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

    public override void gameWindowSizeChanged(Rectangle oldBounds, Rectangle newBounds)
    {
      base.gameWindowSizeChanged(oldBounds, newBounds);

      // Update the position of the cheat menu.
      xPositionOnScreen = Game1.viewport.Width / 2 - 200;
      yPositionOnScreen = Game1.viewport.Height / 2 - 200;

      // Update the position of the close button
      closeButton.bounds.X = xPositionOnScreen + width - 50;
      closeButton.bounds.Y = yPositionOnScreen + 20;

      // Reinitialise the buttons to update their positions.
      InitialiseButtons();
    }
  }
}
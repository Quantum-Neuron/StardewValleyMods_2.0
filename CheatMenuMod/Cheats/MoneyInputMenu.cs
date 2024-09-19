using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Menus;

namespace CheatMenuMod.Cheats
{
  /// <summary>
  /// Money Input Menu Modal Class.
  /// </summary>
  public class MoneyInputMenu : IClickableMenu
  {
    private readonly AddMoney addMoney;
    private readonly TextBox textBox;
    private readonly ClickableComponent okButton;

    public MoneyInputMenu(AddMoney addMoney) : base(Game1.viewport.Width / 2 - 200, Game1.viewport.Height / 2 - 200, 400, 400, true)
    {
      this.addMoney = addMoney;

      textBox = new TextBox(Game1.content.Load<Texture2D>("LooseSprites\\textBox"), null, Game1.dialogueFont, Game1.textColor)
      {
        X = xPositionOnScreen + 50,
        Y = yPositionOnScreen + 50,
        Width = 300,
      };

      textBox.Selected = true;
      Game1.keyboardDispatcher.Subscriber = textBox;

      okButton = new ClickableComponent(new Rectangle(xPositionOnScreen + 150,
        yPositionOnScreen + 100, 100, 50), "OK");
    }

    public override void draw(SpriteBatch spriteBatch)
    {
      base.draw(spriteBatch);

      drawTextureBox(spriteBatch, xPositionOnScreen, yPositionOnScreen, width, height, Color.White);
      textBox.Draw(spriteBatch);

      drawTextureBox(spriteBatch, okButton.bounds.X, okButton.bounds.Y, okButton.bounds.Width, okButton.bounds.Height, Color.BlueViolet);
      SpriteText.drawString(spriteBatch, okButton.name, okButton.bounds.X + 20, okButton.bounds.Y + 20);
    }

    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {
      base.receiveLeftClick(x, y, playSound);
      if (okButton.containsPoint(x, y))
      {
        addMoney.AddMoolah(int.Parse(textBox.Text));
        Game1.activeClickableMenu = null;
      }
      else
      {
        Game1.addHUDMessage(new HUDMessage("Invalid amount entered.", 3));
      }
    }
  }
}

namespace CheatMenuMod
{
  /// <summary>
  /// Base Cheat Class.
  /// </summary>
  public abstract class Cheat
  {
    /// <summary>
    /// Name of the cheat.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Activate the cheat.
    /// </summary>
    public abstract void Activate();

    /// <summary>
    /// Deactivate the cheat. 
    /// </summary>
    public abstract void Deactivate();
  }
}

namespace RoleplayGame.Items;
/// <summary>
/// Casco para defenderse.
/// </summary>
public class Shell : IDefenseItem
{
    /// <summary>
    /// Poder de defensa.
    /// </summary>
    /// <value></value>
    public int DefensePower
    {
        get
        {
            return 100;
        }
    }

    public override string ToString()
    {
        return "Shell";
    }
}
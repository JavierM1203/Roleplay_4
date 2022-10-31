namespace RoleplayGame.Items;
/// <summary>
/// Casco para defenderse.
/// </summary>
public class Helmet : IDefenseItem
{
    /// <summary>
    /// Poder de defensa.
    /// </summary>
    /// <value></value>
    public int DefensePower
    {
        get
        {
            return 50;
        }
    }
}
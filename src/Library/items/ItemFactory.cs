namespace RoleplayGame.Items
{
    /// <summary>
    /// Tipos de elementos
    /// </summary>
    public enum ItemType
    {
        Magic = 1,
        Robes = 2,
        Shield = 3,
        Sword = 4,
        Helmet = 5,
        Bazooka = 6,
        Stick = 7,
        Shell = 8,
        FlameSword = 9,
    }

    /// <summary>
    /// Creador de elementos. 
    /// </summary>
    public class ItemFactory
    {
        /// <summary>
        /// Permite crear elementos dado un tipo de elemento.
        /// </summary>
        /// <param name="type">El tipo de elemento</param>
        /// <returns>El elemento</returns>
        public static IItem GetItem(ItemType type)
        {
            switch (type)
            {
                case ItemType.Magic: return new Magic();
                case ItemType.Robes: return new Robes();
                case ItemType.Shield: return new Shield();
                case ItemType.Sword: return new Sword();
                case ItemType.Helmet: return new Helmet();
                case ItemType.Bazooka: return new Bazooka();
                case ItemType.Stick: return new Stick();
                case ItemType.Shell: return new Shell();
                case ItemType.FlameSword: return new FlameSword();

                default: return null;
            }
        }
    }
}
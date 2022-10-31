namespace RoleplayGame.Items
{

    /// <summary>
    /// Espada. Permite atacar.
    /// </summary>
    public class Sword : IAttackItem{

        /// <summary>
        /// El poder de ataque
        /// </summary>
        /// <value></value>
        public int AttackPower
        {
            get
            {
                return 120;
            }
        }
        public override string ToString()
        {
            return "Sword";
        }
    }

    
}
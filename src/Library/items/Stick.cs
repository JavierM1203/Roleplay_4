namespace RoleplayGame.Items
{

    /// <summary>
    /// Palo. Permite atacar.
    /// </summary>
    public class Stick : IAttackItem{

        /// <summary>
        /// El poder de ataque
        /// </summary>
        /// <value></value>
        public int AttackPower
        {
            get
            {
                return 40;
            }
        }
        public override string ToString()
        {
            return "Stick";
        }
    }

    
}
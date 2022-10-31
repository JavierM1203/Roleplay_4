namespace RoleplayGame.Items
{
    public class FlameSword : IAttackItem
    {
        Sword baseSword = new Sword();
        Magic flame = new Magic();

        public int AttackPower
        {
            get
            {
                return (baseSword.AttackPower + flame.AttackPower);
            }
        }
    }
}
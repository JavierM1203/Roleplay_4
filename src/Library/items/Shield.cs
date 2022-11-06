namespace RoleplayGame.Items
{
    public class Shield : IDefenseItem
    {
        public int DefensePower
        {
            get
            {
                return 10;
            }
        }

        public override string ToString()
        {
            return "Shield";
        }
    }
}
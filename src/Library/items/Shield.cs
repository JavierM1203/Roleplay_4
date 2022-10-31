namespace RoleplayGame.Items
{
    public class Shield : IDefenseItem
    {
        public int DefensePower
        {
            get
            {
                return 30;
            }
        }

        public override string ToString()
        {
            return "Shield";
        }
    }
}
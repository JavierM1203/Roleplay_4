namespace RoleplayGame.Items
{


    public class Bazooka : IAttackItem 
    {
            
        public int AttackPower
            {   
                get
                {
                    return 50;
                }
            } 
        public override string ToString()
            {
                return "Bazooka";
            }
    }
}
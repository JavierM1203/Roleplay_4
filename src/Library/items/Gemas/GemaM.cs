namespace RoleplayGame.Items 
{
    public class GemaM : IAttackItem, IDefenseItem , IGema
    {

         public int DefensePower
        {
            get
            {
                return 50;
            }
        }
         public int AttackPower
        {
            get
            {
                return 50;
            }
        }

       
       
    }
}
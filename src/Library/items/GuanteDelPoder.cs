using System.Collections.Generic;
using RoleplayGame.Characters;
namespace RoleplayGame.Items 


{
    public class GuanteDelPoder : IAttackItem, IDefenseItem
    {

        private List<IGema> allUsers = new List<IGema>();
       
      
        public int AttackPower
        {
            get
            {
                return 70;
            }
        }

         public int DefensePower
        {
            get
            {
                return 70;
            }
        }
        public void AgregarGema(IGema g, Character ch)
        {
           
        }


    }
}
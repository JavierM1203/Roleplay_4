using System.Collections.Generic;
using RoleplayGame.Characters;
namespace RoleplayGame.Items 


{
    public class GuanteDelPoder : IAttackItem, IDefenseItem
    {

        private List<IGema> allGemas = new List<IGema>();
       
        
        public int AttackPower
        {
            get
            {
                int attack = 0;
                
                foreach (IGema g in allGemas)
                {
                    attack += g.AttackPower;
                }
                return attack;
            }
        }

         public int DefensePower
        {
            get
            {
                int defense = 0;
                
                foreach (IGema g in allGemas)
                {
                    defense += g.DefensePower;
                }
                return defense;
            }
        }
        public void AgregarGema(IGema g)
        {
            if (!allGemas.Contains(g) )
            {
              allGemas.Add(g);     
            }
        }
        public void RemoveGema(IGema g)
        {
            allGemas.Remove(g);
        }

    }
}
using System.Collections.Generic;
using RoleplayGame.Items;

namespace RoleplayGame.Characters
{
    /// <summary>
    /// Personaje Elfo
    /// </summary>
    public class Dwarf : Character
    {
        public Dwarf(string name)
            : base(name)
        {
            this.Health = 150;
            this.AddItem(new Robes());
            this.AddItem(new Helmet());
            this.AddItem(new Sword());
        }
    }
}
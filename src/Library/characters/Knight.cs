using System.Collections.Generic;
using RoleplayGame.Items;

namespace RoleplayGame.Characters
{
    /// <summary>
    /// Personaje Elfo
    /// </summary>
    public class Knight : Character
    {
        public Knight(string name)
            : base(name)
        {
            this.Health = 120;
            this.AddItem(new Robes());
            this.AddItem(new Sword());
            this.AddItem(new Shield());
        }
    }
}
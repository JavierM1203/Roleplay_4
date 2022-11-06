using RoleplayGame.Characters;
using RoleplayGame.Items;
using RoleplayGame.Encounters;
using RoleplayGame.Scenarios;
using System.Collections.Generic;
using System;
using System.Linq;

//Se intentó crear un nuevo escenario pero no logra con todo lo pedido en la parte VI.
//Solamente se logró asignar items al azar.

namespace Program
{
    /// <summary>
    /// Este escenario permite crear personajes, items y encuentros
    /// desde la terminal en forma dinámica.
    /// </summary>
    public class ConsoleOurScenario: IScenario
    {
        /// <summary>
        /// Los personajes creados
        /// </summary>
        /// <typeparam name="Character"></typeparam>
        /// <returns></returns>
        protected List<Character> characters = new List<Character>();

        List<IItem> allItems = new List<IItem>(){new Bazooka(), new FlameSword(), new Helmet(), new Robes(), new Shell(), new Shield(), new Stick(), new Sword()};

        /// <summary>
        /// Código de inicialización del escenario.
        /// </summary>
        public virtual void Setup()
        {
            this.BuildCharacters();
        }

        /// <summary>
        /// Código de ejecución del escenario.
        /// </summary>
        public virtual void Run()
        {
            this.RunEncounters();
        }

        /// <summary>
        /// Ejecución de un encuentro. Se construye de forma
        /// dinámica mediante interacción con el usuario.
        /// </summary>
        protected virtual void RunEncounters()
        {
            Encounter encounter = this.BuildEncounter();
            while (encounter != null)
            {
                encounter.DoEncounter();
                this.RemoveDeadCharacters();
                encounter = this.BuildEncounter();
            }
        }

        /// <summary>
        /// Construcción de un encuentro mediante entrada por la
        /// terminal.
        /// 
        /// Si quedan menos de dos personajes, la función retorna null.
        /// Si la entrada es vacía se retorna null.
        /// </summary>
        /// <returns>El encuentro creado</returns>
        protected virtual Encounter BuildEncounter()
        {
            if (this.LessThanTwoCharactersLeft)
            {
                return null;
            }
            EncounterType type = this.ReadEncounterType();
            if (type == default(EncounterType))
            {
                return null;
            }

            // Dwarf dwarf = new Dwarf("Gimli");
            // Elf elf = new Elf("Legolas");
            // Knight knight = new Knight("Eomer");
            // Wizard wizard = new Wizard("Gandalf");

            Character character1 = this.SelectCharacter("Select one character:");
            Character character2 = this.SelectCharacter("Select another character:");

            while (character1.Items.Count != 0)
            {
                character1.RemoveItem(character1.Items[0]);
            }
            while (character2.Items.Count != 0)
            {
                character2.RemoveItem(character2.Items[0]);
            }   

            Encounter encounter = EncounterFactory.GetEncounter(type, character1, character2);
            encounter.Reporter = new ConsoleReporter();
            return encounter;
        }

        protected bool LessThanTwoCharactersLeft
        {
            get
            {
                return characters.Count < 2;
            }
        }

        /// <summary>
        /// Construcción de los personajes mediante interacción por
        /// la terminal.
        /// 
        /// La función termina cuando la entrada de usuario es vacía.
        /// </summary>
        protected virtual void BuildCharacters()
        {
            CharacterType type = this.ReadCharacterType();
            while (type != default(CharacterType))
            {
                string name = this.ReadCharacterName();
                if (name == "")
                {
                    name = $"The {type}";
                }

                Character character = CharacterFactory.GetCharacter(type, name);
                Random r = new Random();
                for (int i = 1; i<2; i++)
                {
                    int randomIndex = r.Next(0, 7);
                    character.AddItem(allItems[randomIndex]);
                }            
                
                this.characters.Add(character);
                
                Console.WriteLine($"Built {character}");

                type = this.ReadCharacterType();
            }
        }

        /// <summary>
        /// Lectura por consola de un tipo de personaje.
        /// Retorna 0 si la entrada es vacía.
        /// </summary>
        /// <returns>Tipo de personaje o 0</returns>
        private CharacterType ReadCharacterType()
        {
            return ConsoleListSelector<CharacterType>.Select(
                Enum.GetValues(typeof(CharacterType)).Cast<CharacterType>().ToList(),
                "Select a character type:"
            );
        }

        /// <summary>
        /// Lectura por consola de nombre para un personaje.
        /// </summary>
        /// <returns>El nombre ingresado</returns>
        private string ReadCharacterName()
        {
            Console.Write("Type character name: ");
            return Console.ReadLine().Trim();
        }

        /// <summary>
        /// Creación de items mediante interacción con el usuario por
        /// consola.
        /// 
        /// La función finaliza cuando el usuario ingresa la cadena vacía.
        /// </summary>
        /// <returns>Lista de items creados</returns>
        private List<IItem> ReadCharacterItems()
        {
            List<IItem> items = new List<IItem>();

            Console.WriteLine("Let's add items to your character");

            ItemType type = this.ReadItemType();
            Console.WriteLine(type);
            while (type != default(ItemType))
            {
                IItem item = ItemFactory.GetItem(type);
                items.Add(item);
                this.AddObjectsToItem(item);

                type = this.ReadItemType();
            }
            return items;
        }

        /// <summary>
        /// Función template para agregar objectos a un item que los requiere.
        /// Por ejemplo, para un item "Guante de Poder" que utiliza Gemas, aquí
        /// se debería leer cuántas Gemas se le quieren agregar mediante el 
        /// ingreso del usuario por la terminal.
        /// </summary>
        /// <param name="item">El item al que se agregarán objectos</param>
        protected virtual void AddObjectsToItem(IItem item)
        {
            /*
                Si un item se compone de otros (como un Guante de Poder),
                puedes agregar aquí el código necesario para interactuar
                con el usuario.
            */
        }

        /// <summary>
        /// Lee un tipo de item por la terminal. Retorna 0 si ningún tipo
        /// fue seleccionado.
        /// </summary>
        /// <returns>El tipo de item, o 0</returns>
        private ItemType ReadItemType()
        {
            return ConsoleListSelector<ItemType>.Select(
                Enum.GetValues(typeof(ItemType)).Cast<ItemType>().ToList(),
                "Select an item:"
            );
        }

        /// <summary>
        /// Lee un tipo de encuentro por consola. Retorna el tipo de encuentro
        /// seleccionado, o 0 para la selección vacía.
        /// </summary>
        /// <returns>El tipo seleccionado, o 0.</returns>
        private EncounterType ReadEncounterType()
        {
            return ConsoleListSelector<EncounterType>.Select(
                Enum.GetValues(typeof(EncounterType)).Cast<EncounterType>().ToList(),
                "Select an encounter type:"
            );
        }

        /// <summary>
        /// Permite seleccionar un personaje por consola. Muestra una lista
        /// con todos los personajes disponibles.
        /// 
        /// Retorna el personaje elegido. Si no se escoge ninguno, pregunta
        /// nuevamente hasta que uno sea seleccionado.
        /// </summary>
        /// <param name="message">Mensaje de prompt para mostrar</param>
        /// <returns>El personaje escogido</returns>
        private Character SelectCharacter(string message = "Select a character:")
        {
            Character selected = ConsoleListSelector<Character>.Select(
                this.characters,
                message
            );
            if (selected == null)
            {
                return SelectCharacter();
            }
            return selected;
        }

        /// <summary>
        /// Permite seleccionar un item por consola. Muestra una lista
        /// con los items disponibles.
        /// 
        /// Retorna el item elegido. Si no se escoge ninguno, pregunta
        /// nuevamente hasta que uno sea seleccionado.
        /// </summary>
        /// <param name="items">Lista de items disponibles para elegir</param>
        /// <param name="message">Mensaje de prompt para mostrar</param>
        /// <returns>El item escogido</returns>
        private IItem SelectItem(List<IItem> items, string message = "Select an item:")
        {
            IItem selected = ConsoleListSelector<IItem>.Select(items,message);
            if (selected == null)
            {
                return SelectItem(items, message);
            }
            return selected;
        }

        /// <summary>
        /// Quita personajes muertos (vida = 0) de la lista de personajes.
        /// </summary>
        private void RemoveDeadCharacters()
        {
            List<Character> dead = new List<Character>();
            foreach(Character character in this.characters)
            {
                if (character.IsDead)
                {
                    dead.Add(character);
                }
            }
            foreach (Character deadCharacter in dead)
            {
                this.characters.Remove(deadCharacter);
            }
        }

    }
}
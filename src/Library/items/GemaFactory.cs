namespace RoleplayGame.Items
{
 public enum GemaType
    {
        Tiempo = 1,
        Espacio = 2,
        Poder = 3,
        Alma = 4,
        Mente = 5,
        Realidad = 6,
    }

    public class GemaFactory{
        public static IItem GetGema(GemaType type)
        {
            switch (type)
            {
                case GemaType.Tiempo: return new GemaT();
                case GemaType.Espacio: return new GemaE();
                case GemaType.Poder: return new GemaP();
                case GemaType.Alma: return new GemaA();
                case GemaType.Mente: return new GemaM();
                case GemaType.Realidad: return new GemaR();

                default: return null;
            }
        }
    }
}
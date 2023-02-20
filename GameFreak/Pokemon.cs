namespace GameFreak
{
    public class Pokemon
    {
        public enum PokemonType
        {
            UnsupportedType,
            Water,
            Fire,
            Grass
        }

        public readonly string Name;
        public readonly PokemonType Type;

        internal Pokemon(string name, PokemonType type)
        {
            Name = name;
            Type = type;
        }
    }
}
namespace GameFreak
{
    public class PokemonFactory
    {
        public Pokemon CreatePokemon(string name, string type)
        {
            if (!Enum.TryParse(type, ignoreCase: true, out Pokemon.PokemonType pokemonType))
            {
                pokemonType = Pokemon.PokemonType.UnsupportedType;
            }

            return new Pokemon(name, pokemonType);
        }
    }
}

using Xunit;

namespace GameFreak
{
    public class XUnitTest
    {
        [Fact]
        public void IteratingOverData()
        {
            /// Tuple(PokemonName, PokemonType, ExpectedPokemonType
            var pokemonData = new List<Tuple<string, string, Pokemon.PokemonType>>()
            {
                new ("Bulbasaur", "Grass", Pokemon.PokemonType.Grass),
                new ("Charmander", "Fire", Pokemon.PokemonType.Fire),
                new ("Squirtle", "Water", Pokemon.PokemonType.Water),
                new ("ProfessorOak", "Human", Pokemon.PokemonType.UnsupportedType),
            };

            var pokemonFactory = new PokemonFactory();

            foreach (var pd in pokemonData)
            {
                var pokemon = pokemonFactory.CreatePokemon(pd.Item1, pd.Item2);
                Assert.Equal(pd.Item3, pokemon.Type);
            }
        }

        [Theory]
        [InlineData("Bulbasaur", "Grass", Pokemon.PokemonType.Grass)]
        [InlineData("Charmander", "Fire", Pokemon.PokemonType.Fire)]
        [InlineData("Squirtle", "Water", Pokemon.PokemonType.Water)]
        [InlineData("ProfessorOak", "Human", Pokemon.PokemonType.UnsupportedType)]
        public void UsingInlineData(string pokemonName, string pokemonType, Pokemon.PokemonType expectedPokemonType)
        {
            var pokemonFactory = new PokemonFactory();

            var pokemon = pokemonFactory.CreatePokemon(pokemonName, pokemonType);

            Assert.Equal(expectedPokemonType, pokemon.Type);
        }

        public static IEnumerable<object[]> PokemonData => new[]
        {
            new object[] { "Bulbasaur", "Grass", Pokemon.PokemonType.Grass },
            new object[] { "Charmander", "Fire", Pokemon.PokemonType.Fire },
            new object[] { "Squirtle", "Water", Pokemon.PokemonType.Water },
            new object[] { "ProfessorOak", "Human", Pokemon.PokemonType.UnsupportedType },
        };

        [Theory]
        [MemberData(nameof(PokemonData))]
        public void UsingMemberData(string pokemonName, string pokemonType, Pokemon.PokemonType expectedPokemonType)
        {
            var pokemonFactory = new PokemonFactory();

            var pokemon = pokemonFactory.CreatePokemon(pokemonName, pokemonType);

            Assert.Equal(expectedPokemonType, pokemon.Type);
        }
    }
}

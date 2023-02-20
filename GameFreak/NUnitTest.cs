using NUnit.Framework;

namespace GameFreak
{
    [TestFixture]
    public class NUnitTest
    {
        [Test]
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
                Assert.AreEqual(pd.Item3, pokemon.Type);
            }
        }

        [TestCase("Bulbasaur", "Grass", Pokemon.PokemonType.Grass)]
        [TestCase("Charmander", "Fire", Pokemon.PokemonType.Fire)]
        [TestCase("Squirtle", "Water", Pokemon.PokemonType.Water)]
        [TestCase("ProfessorOak", "Human", Pokemon.PokemonType.UnsupportedType)]
        public void UsingTestCase(string pokemonName, string pokemonType, Pokemon.PokemonType expectedPokemonType)
        {
            var pokemonFactory = new PokemonFactory();

            var pokemon = pokemonFactory.CreatePokemon(pokemonName, pokemonType);

            Assert.AreEqual(expectedPokemonType, pokemon.Type);
        }

        public static IEnumerable<object[]> PokemonData => new[]
        {
            new object[] { "Bulbasaur", "Grass", Pokemon.PokemonType.Grass },
            new object[] { "Charmander", "Fire", Pokemon.PokemonType.Fire },
            new object[] { "Squirtle", "Water", Pokemon.PokemonType.Water },
            new object[] { "ProfessorOak", "Human", Pokemon.PokemonType.UnsupportedType },
        };

        [TestCaseSource(nameof(PokemonData))]
        public void UsingTestCaseSource(string pokemonName, string pokemonType, Pokemon.PokemonType expectedPokemonType)
        {
            var pokemonFactory = new PokemonFactory();

            var pokemon = pokemonFactory.CreatePokemon(pokemonName, pokemonType);

            Assert.AreEqual(expectedPokemonType, pokemon.Type);
        }
    }
}

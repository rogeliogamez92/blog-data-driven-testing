using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFreak
{
    [TestClass]
    public class MSUnitTest
    {
        [TestMethod]
        public void IteratingOverData()
        {
            /// Tuple(PokemonName, PokemonType, ExpectedPokemonType
            var pokemonData = new List<Tuple<string, string, Pokemon.PokemonType>>()
            {
                new ("Bulbasaur", "Grass", Pokemon.PokemonType.Grass),
                new ("Charmander", "FireError", Pokemon.PokemonType.Fire),
                new ("Squirtle", "WaterError", Pokemon.PokemonType.Water),
                new ("ProfessorOak", "Human", Pokemon.PokemonType.UnsupportedType),
            };

            var pokemonFactory = new PokemonFactory();

            foreach (var pd in pokemonData)
            {
                var pokemon = pokemonFactory.CreatePokemon(pd.Item1, pd.Item2);
                Assert.AreEqual(pd.Item3, pokemon.Type);
            }
        }

        [TestMethod]
        [DataRow("Bulbasaur", "Grass", Pokemon.PokemonType.Grass)]
        [DataRow("Charmander", "FireError", Pokemon.PokemonType.Fire)]
        [DataRow("Squirtle", "WaterError", Pokemon.PokemonType.Water)]
        [DataRow("ProfessorOak", "Human", Pokemon.PokemonType.UnsupportedType)]
        public void UsingDataRow(string pokemonName, string pokemonType, Pokemon.PokemonType expectedPokemonType)
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

        //[TestMethod]
        //[DynamicData(nameof(PokemonData))]
        public void UsingDynamicData(string pokemonName, string pokemonType, Pokemon.PokemonType expectedPokemonType)
        {
            var pokemonFactory = new PokemonFactory();

            var pokemon = pokemonFactory.CreatePokemon(pokemonName, pokemonType);

            Assert.AreEqual(expectedPokemonType, pokemon.Type);
        }
    }
}
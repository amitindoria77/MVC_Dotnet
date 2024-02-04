using WebApplication1_Demo.Models;

namespace WebApplication1_Demo.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);

        Pokemon GetPokemon(string name);

        decimal GetPokenRating(int pokeId);

        bool PokemonExists(int pokeId);


    }
}

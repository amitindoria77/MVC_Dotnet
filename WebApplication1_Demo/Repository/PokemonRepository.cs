﻿using WebApplication1_Demo.Data;
using WebApplication1_Demo.Interfaces;
using WebApplication1_Demo.Models;

namespace WebApplication1_Demo.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokenRating(int pokeId)
        {
            var review =  _context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if (review.Count() <= 0)
                return 0;   
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }  

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId); 
        }

    }

     
}

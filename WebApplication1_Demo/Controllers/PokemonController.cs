using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1_Demo.Dto;
using WebApplication1_Demo.Interfaces;
using WebApplication1_Demo.Models;

namespace WebApplication1_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IPokemonRepository _pokemonRepository;

        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetPokemon(int pokeId)
        {
            if(!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();

            //var pokemon = _pokemonRepository.GetPokemon(pokeId);

            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        public IActionResult GetPokemons()
        {
           var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            // Without automapper we need to write below code
            //var newPoke = new Pokemon()
            //{ 
            //   Name = pokemons.Name,
            //}

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
             
        }

      

    }
}

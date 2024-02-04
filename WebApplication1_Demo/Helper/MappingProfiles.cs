using AutoMapper;
using WebApplication1_Demo.Dto;
using WebApplication1_Demo.Models;

namespace WebApplication1_Demo.Helper
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
        }

    }
}

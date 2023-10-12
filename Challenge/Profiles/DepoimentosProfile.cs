using AutoMapper;
using Challenge.Data.Dtos;
using Challenge.Models;

namespace Challenge.Profiles
{
    public class DepoimentosProfile : Profile
    {
        public DepoimentosProfile()
        {
            CreateMap<CreateDepoimento, Depoimentos>();
            CreateMap<UpdateDepoimento, Depoimentos>();
            CreateMap<Depoimentos, UpdateDepoimento>();
            CreateMap<Depoimentos, ReadDepoimento>();

        }
    }
}
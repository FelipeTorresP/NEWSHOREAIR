using AutoMapper;

namespace NEWSHOREAIR.Mapper
{
    using Business = Business.Models;
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Business.Transport, Dto.Transport>();
            CreateMap<Business.Flight, Dto.Flight>();
            CreateMap<Business.Journey, Dto.Journey>();
            CreateMap<Dto.Transport, Business.Transport>();
            CreateMap<Dto.Journey, Business.Journey>();
            CreateMap<Dto.Flight, Business.Flight>();
        }
    }
}

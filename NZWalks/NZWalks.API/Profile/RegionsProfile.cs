using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;

namespace NZWalks.API.Profile
{
    public class RegionsProfile : AutoMapper.Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
                .ReverseMap();
        }
    }
}

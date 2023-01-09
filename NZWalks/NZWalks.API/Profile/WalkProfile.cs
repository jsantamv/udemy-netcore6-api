using AutoMapper;
namespace NZWalks.API.Profile
{
    public class WalkProfile : AutoMapper.Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>()
                .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
                .ReverseMap();

        }
    }
}

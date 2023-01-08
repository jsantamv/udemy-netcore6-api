using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO.Walk
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        public NZWalks.API.Models.Domain.Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}

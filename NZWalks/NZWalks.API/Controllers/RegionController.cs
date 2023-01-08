using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO.Region;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionsRepostory regionsRepostory;
        private readonly IMapper mapper;

        public RegionController(IRegionsRepostory regionsRepostory, IMapper mapper)
        {
            this.regionsRepostory = regionsRepostory;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionsRepostory.GetAllAsync();

            //Con esto evitamos hacer el mapeo a mano
            // Utilizamos AutoMapper que se injecta desde program
            var dto = mapper.Map<List<Region>>(regions);
            return Ok(dto);
        }

        [HttpGet]
        [Route("{id:guid}")] // Esto restrigi ya que definimos el tipo 
        [ActionName("GetRegionAsync")] //esto para llamarlo en salvar
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionsRepostory.GetAsync(id);
            var dto = mapper.Map<Models.DTO.Region.Region>(region);
            return Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegion)
        {
            //Request(DTO) to domain Model
            Models.Domain.Region region = new()
            {
                Code = addRegion.Code,
                Area = addRegion.Area,
                Lat = addRegion.Lat,
                Long = addRegion.Long,
                Name = addRegion.Name,
                Population = addRegion.Population,
            };

            // Pass details to Repository
            region = await regionsRepostory.AddAsync(region);

            // Convert bact to DTO
            Models.Domain.Region regionDto = new()
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population,
            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDto.Id }, regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")] // Esto restrigi ya que definimos el tipo 
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            //Get Region from de database
            var deleteRegion = await regionsRepostory.DeleteAsync(id);

            //If not found that
            if (deleteRegion == null)
            {
                return NotFound();
            }

            // Convert DTO
            Models.Domain.Region regionDto = new()
            {
                Code = deleteRegion.Code,
                Area = deleteRegion.Area,
                Lat = deleteRegion.Lat,
                Long = deleteRegion.Long,
                Name = deleteRegion.Name,
                Population = deleteRegion.Population,
            };

            //Return Ok Response
            return Ok(regionDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            //Convert DTO to Domain Model
            Models.Domain.Region region = new()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population,
            };


            //Update Region using Repository

            region = await regionsRepostory.UpdateAsync(id, region);

            //if null then notFound
            if (region == null)
            {
                return NotFound();
            }

            //Convert Domain to back DTO
            Models.Domain.Region regionDto = new()
            {
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population,
            };

            //return Ok Response. 
            return Ok(regionDto);
        }

    }
}

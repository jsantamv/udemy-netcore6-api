using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository regionsRepostory;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionsRepostory, IMapper mapper)
        {
            this.regionsRepostory = regionsRepostory;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
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
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionsRepostory.GetAsync(id);
            var dto = mapper.Map<Models.DTO.Region>(region);
            return Ok(dto);
        }


        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            // Validate The Request
            //if (!ValidateAddRegionAsync(addRegionRequest))
            //{
            //    return BadRequest(ModelState);
            //}

            //Request(DTO) to domain Model
            Models.Domain.Region region = new()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population,
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
        [Authorize(Roles = "writer")]
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
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {

            // Validate the incoming request
            //if (!ValidateUpdateRegionAsync(updateRegionRequest))
            //{
            //    return BadRequest(ModelState);
            //}

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

        //#region Private methods

        //private bool ValidateAddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        //{
        //    if (addRegionRequest == null)
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest),
        //            $"Add Region Data is required.");
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(addRegionRequest.Code))
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Code),
        //            $"{nameof(addRegionRequest.Code)} cannot be null or empty or white space.");
        //    }

        //    if (string.IsNullOrWhiteSpace(addRegionRequest.Name))
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Name),
        //            $"{nameof(addRegionRequest.Name)} cannot be null or empty or white space.");
        //    }

        //    if (addRegionRequest.Area <= 0)
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Area),
        //            $"{nameof(addRegionRequest.Area)} cannot be less than or equal to zero.");
        //    }

        //    if (addRegionRequest.Population < 0)
        //    {
        //        ModelState.AddModelError(nameof(addRegionRequest.Population),
        //            $"{nameof(addRegionRequest.Population)} cannot be less than zero.");
        //    }

        //    if (ModelState.ErrorCount > 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //private bool ValidateUpdateRegionAsync(Models.DTO.UpdateRegionRequest updateRegionRequest)
        //{
        //    if (updateRegionRequest == null)
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest),
        //            $"Add Region Data is required.");
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(updateRegionRequest.Code))
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Code),
        //            $"{nameof(updateRegionRequest.Code)} cannot be null or empty or white space.");
        //    }

        //    if (string.IsNullOrWhiteSpace(updateRegionRequest.Name))
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Name),
        //            $"{nameof(updateRegionRequest.Name)} cannot be null or empty or white space.");
        //    }

        //    if (updateRegionRequest.Area <= 0)
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Area),
        //            $"{nameof(updateRegionRequest.Area)} cannot be less than or equal to zero.");
        //    }

        //    if (updateRegionRequest.Population < 0)
        //    {
        //        ModelState.AddModelError(nameof(updateRegionRequest.Population),
        //            $"{nameof(updateRegionRequest.Population)} cannot be less than zero.");
        //    }

        //    if (ModelState.ErrorCount > 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //#endregion

    }
}

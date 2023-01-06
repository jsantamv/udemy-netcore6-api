using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

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
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionsRepostory.GetAllAsync();

            //Con esto evitamos hacer el mapeo a mano
            // Utilizamos AutoMapper que se injecta desde program
            var dto = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(dto);
        }
    }
}

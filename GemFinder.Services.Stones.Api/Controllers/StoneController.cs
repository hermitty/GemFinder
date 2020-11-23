using System.Collections.Generic;
using System.Threading.Tasks;
using GemFinder.Services.Stones.Application.DTO;
using GemFinder.Services.Stones.Application.Queries;
using GemFinder.Utils.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GemFinder.Services.Stones.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoneController : ControllerBase
    {
        private readonly IQueryDispatcher queryDispatcher;
        public StoneController(IQueryDispatcher queryDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<StoneImageDTO>> GetImagesStones()
        {
            var result = await queryDispatcher.QueryAsync(new GetStonesImages());
            return result;
        }
    }
}

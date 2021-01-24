using System.Collections.Generic;
using System.Threading.Tasks;
using GemFinder.Services.Stones.Application.Commands;
using GemFinder.Services.Stones.Application.DTO;
using GemFinder.Services.Stones.Application.Queries;
using GemFinder.Utils.CQRS.Commands;
using GemFinder.Utils.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GemFinder.Services.Stones.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoneController : ControllerBase
    {
        private readonly IQueryDispatcher queryDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        public StoneController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<StoneImageDTO>> GetStones([FromHeader] GetStonesImages request)
            => await queryDispatcher.QueryAsync(request);

        [HttpGet("[action]/{label}")]
        public async Task<StoneDTO> GetStone([FromHeader] GetStoneInfo request) 
            => await queryDispatcher.QueryAsync(request);

        [HttpPost("[action]")]
        public async Task AddImagesToStone([FromBody] AddImagesToStone request)
            => await commandDispatcher.SendAsync(request);

        [HttpPost("[action]")]
        public async Task DeleteImage([FromBody] DeleteImage request) 
            => await commandDispatcher.SendAsync(request);

        [HttpPost("[action]")]
        public async Task DeleteStone([FromBody] DeleteStone request) 
            => await commandDispatcher.SendAsync(request);
    }
}

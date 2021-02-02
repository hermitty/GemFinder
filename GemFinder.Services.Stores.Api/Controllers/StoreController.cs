using System.Collections.Generic;
using System.Threading.Tasks;
using GemFinder.Services.Stores.Application.Commands;
using GemFinder.Services.Stores.Application.DTO;
using GemFinder.Services.Stores.Application.Queries;
using GemFinder.Utils.CQRS.Commands;
using GemFinder.Utils.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace GemFinder.Services.Stores.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IQueryDispatcher queryDispatcher;
        private readonly ICommandDispatcher commandDispatcher;

        public StoreController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            this.queryDispatcher = queryDispatcher;
            this.commandDispatcher = commandDispatcher;
        }

        [HttpGet("[action]/{StoreId}")]
        public async Task<StoreDTO> GetStore([FromHeader] GetStore request)
          => await queryDispatcher.QueryAsync(request);

        [HttpGet("[action]/{StoreId}")]
        public async Task<IEnumerable<OpinionDTO>> GetStoreOpinions([FromHeader] GetStoreOpinions request)
          => await queryDispatcher.QueryAsync(request);

        [HttpGet("[action]")]
        public async Task<IEnumerable<StoreShortDTO>> GetStores([FromHeader] GetStores request)
           => await queryDispatcher.QueryAsync(request);

        [HttpGet("[action]/{Stones}")]
        public async Task<IEnumerable<StoreShortDTO>> GetStoresByCriteria([FromHeader] GetStoresByCriteria request)
           => await queryDispatcher.QueryAsync(request);

        [HttpPost("[action]")]
        public async Task AddOpinion([FromBody] AddOpinion request)
           => await commandDispatcher.SendAsync(request);

        [HttpPost("[action]")]
        public async Task AddStore([FromBody] AddStore request)
           => await commandDispatcher.SendAsync(request);

        [HttpDelete("[action]")]
        public async Task DeleteStore([FromBody] DeleteStore request)
           => await commandDispatcher.SendAsync(request);

        [HttpPost("[action]")]
        public async Task UpdateStore([FromBody] UpdateStore request)
           => await commandDispatcher.SendAsync(request);
    }
}

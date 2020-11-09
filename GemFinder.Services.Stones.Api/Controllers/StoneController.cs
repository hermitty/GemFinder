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

        [HttpGet("[action]/{label}")]
        public async Task<SingleImageStoneDto> GetSingleImageStone(string label)
        {
            var query = new GetSingleImageStone()
            {
                Label = label
            };
            var result = await queryDispatcher.QueryAsync(query);
            return result;
        }
    }
}

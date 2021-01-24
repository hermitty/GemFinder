using GemFinder.Services.Stones.Core.Repositories;
using GemFinder.Utils.CQRS.Commands;
using System.Threading.Tasks;

namespace GemFinder.Services.Stones.Application.Commands.Handlers
{
    public class StoneCommandHandler : ICommandHandler<AddImagesToStone>, ICommandHandler<DeleteImage>, ICommandHandler<DeleteStone>
    {
        private readonly IStoneRepository repo;

        public StoneCommandHandler(IStoneRepository repo)
        {
            this.repo = repo;
        }

        public async Task HandleAsync(AddImagesToStone command)
        {
            var stone = await repo.GetStone(command.Label);
            if (stone == null)
                throw new System.Data.DataException();

            stone.AddImages(command.ImageNames);
            await repo.UpdateStone(stone);
        }

        public async Task HandleAsync(DeleteStone command)
        {
            var stone = await repo.GetStone(command.Label);
            if (stone == null)
                throw new System.Data.DataException();

            await repo.DeleteStone(stone);
        }

        public async Task HandleAsync(DeleteImage command)
        {
            var image = await repo.GetImage(command.StoneName);
            if (image == null)
                throw new System.Data.DataException();

            await repo.DeleteImage(image);
        }
    }
}

using GemFinder.Services.Stores.Application.Commands;
using GemFinder.Services.Stores.Core.Entities;
using GemFinder.Services.Stores.Core.Repositories;
using GemFinder.Utils.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemFinder.Services.Stores.Application.commands.Handlers
{
    public class StorecommandHandler : ICommandHandler<AddOpinion>, ICommandHandler<AddStore>, ICommandHandler<DeleteStore>
    {
        private readonly IStoreRepository repo;

        public StorecommandHandler(IStoreRepository repo)
        {
            this.repo = repo;
        }

        public async Task HandleAsync(AddOpinion command)
        {
            var store = await repo.GetStore(command.StoreId);
            if (store == null)
                throw new System.Data.DataException();
            var newOpinion = command.Opinion;
            var opinion = new Opinion(newOpinion.Id, newOpinion.UserId, newOpinion.Comment, newOpinion.Rate);
            store.AddOpinion(opinion);
            await repo.UpdateStore(store);
        }

        public async Task HandleAsync(AddStore command)
        {
            var store = new Store()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                Owner = command.Owner,
                References = command.References.Select(x => new Reference(x)).ToList(),
                StoreImages = command.Images.Select(x => new StoreImage(x)).ToList(),
                StoreStones = command.Stones.Select(x => new StoreStone(x)).ToList()
            };
            await repo.AddStore(store);
        }

        public async Task HandleAsync(DeleteStore command)
        {
            var store = await repo.GetStore(command.Id);
            if (store == null)
                throw new System.Data.DataException();

            await repo.DeleteStore(store);
        }
    }
}

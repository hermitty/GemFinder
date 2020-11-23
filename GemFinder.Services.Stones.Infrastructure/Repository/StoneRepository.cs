﻿using GemFinder.ImageProvider;
using GemFinder.Services.Stones.Core.Entities;
using GemFinder.Services.Stones.Core.Repositories;
using GemFinder.Services.Stones.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemFinder.Services.Stones.Infrastructure.Repository
{
    //TODO inject imageProvider
    public class StoneRepository : IStoneRepository
    {
        private readonly Context context;
        public StoneRepository(Context context)
        {
            this.context = context;
        }

        public async Task SynchronizeStonesFromFiles()
        {
            var imageProvider = new ImageProvider.ImageProvider();
            var stoneList = imageProvider.GetStoredImagesInfo().GroupBy(x => x.Label).Select(stone => new Stone(
                new Guid(),
                stone.FirstOrDefault().Label.Replace('_', ' '),
                stone.FirstOrDefault().Label,
                stone.Select(i => new Image(i.Id, i.Path, i.Source, i.FileName)).ToList()
                )).ToList();
            stoneList.ForEach(x => context.Add(x));

            context.SaveChanges();
        }
        public async Task<Stone> GetStone(string label)
        {
            var stone = context.Stones.FirstOrDefault(x => x.Label == label);
            return stone;
        }

        public async Task<Stone> GetStone(Guid id)
        {
            var stone = context.Stones.FirstOrDefault(x => x.Id == id);
            return stone;
        }
    }
}

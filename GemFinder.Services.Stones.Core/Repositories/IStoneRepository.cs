using GemFinder.Services.Stones.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GemFinder.Services.Stones.Core.Repositories
{
    public interface IStoneRepository
    {
        Task<Stone> GetStone(string label);
    }
}

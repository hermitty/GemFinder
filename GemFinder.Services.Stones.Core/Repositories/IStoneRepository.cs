using GemFinder.Services.Stones.Core.Entities;
using System.Threading.Tasks;

namespace GemFinder.Services.Stones.Core.Repositories
{
    public interface IStoneRepository
    {
        Task<Stone> GetStone(string label);
        Task<Image> GetImage(string name);
        Task UpdateStone(Stone stone);
        Task DeleteStone(Stone stone);
        Task DeleteImage(Image image);
    }
}

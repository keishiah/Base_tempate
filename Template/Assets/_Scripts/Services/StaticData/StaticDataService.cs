using _Scripts.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;

namespace _Scripts.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;

        private const string LevelsDataPath = "LevelsData";
        private const string BoostDataLabel = "Boosts";
        
        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async UniTask Initialize()
        {
        }
        
    }
}
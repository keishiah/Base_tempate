using Cysharp.Threading.Tasks;

namespace _Scripts.Services.StaticData
{
    public interface IStaticDataService
    {
        UniTask Initialize();
    }
}
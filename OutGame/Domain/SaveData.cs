using Cysharp.Threading.Tasks;

namespace Prashalt.MusicRun.Domain
{
    public struct SaveData
    {
        public string Name { get; }

        public SaveData(string name)
        {
            Name = name;
        }
    }

    public interface ISaveDataRepository
    {
        UniTask<SaveData> FindAsync(string key);
        UniTask StoreAsync(string key, SaveData saveData);
    }
}

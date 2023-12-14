using Cysharp.Threading.Tasks;
using Prashalt.MusicRun.Domain;
using VContainer;

namespace Prashalt.MusicRun.Application
{
    public class SaveDataService
    {
        private readonly ISaveDataRepository _saveDataRepository;
        
        [Inject]
        public SaveDataService(ISaveDataRepository saveDataRepository)
        {
            _saveDataRepository = saveDataRepository;
        }

        public UniTask<SaveData> FindAsync(string key) => _saveDataRepository.FindAsync(key);
        public UniTask StoreAsync(string key, SaveData saveData) => _saveDataRepository.StoreAsync(key, saveData);

        public async UniTask<SaveDataStatus> CheckSaveDataStatus(SaveData saveData)
        {
            if (string.IsNullOrEmpty(saveData.Name))
            {
                return SaveDataStatus.Init;
            }
            else
            {
                return SaveDataStatus.ok;
            }
        }
    }

    public enum SaveDataStatus
    {
        Init,
        ok
    }
}


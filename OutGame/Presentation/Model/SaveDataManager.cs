using Cysharp.Threading.Tasks;
using Prashalt.MusicRun.Application;
using Prashalt.MusicRun.Domain;
using UniRx;
using VContainer;

namespace Prashalt.MusicRun.Model
{
    public class SaveDataManager
    {
        private readonly SaveDataService _saveDataService;

        private string _defaultSaveDataKey = "Default";

        public readonly ReactiveProperty<SaveData> CurrentSaveData = new();
        
        [Inject]
        public SaveDataManager(SaveDataService saveDataService)
        {
            _saveDataService = saveDataService;
        }

        public async UniTask SaveAsync(SaveData newSave)
        {
            CurrentSaveData.Value = newSave;
            await _saveDataService.StoreAsync(_defaultSaveDataKey, CurrentSaveData.Value);
        }

        public async UniTask FindAsync()
        {
            var data = await _saveDataService.FindAsync(_defaultSaveDataKey);
            if (data.Name is not null) CurrentSaveData.Value = data;
        }

        public async UniTask<string> GetPageNameBySaveDataStatus()
        {
            var status = await _saveDataService.CheckSaveDataStatus(CurrentSaveData.Value);
            var result = status switch
            {
                SaveDataStatus.ok => "StartPage",
                SaveDataStatus.Init => "InitPage",
                _ => null
            };
            return result;
        }
    }   
}

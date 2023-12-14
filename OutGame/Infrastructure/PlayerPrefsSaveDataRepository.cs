using Cysharp.Threading.Tasks;
using Prashalt.MusicRun.Domain;
using UnityEngine;

namespace Prashalt.MusicRun.Infrastructure
{
    public class PlayerPrefsSaveDataRepository : ISaveDataRepository
    {
        private const string _nameKey = "name.";
        public async UniTask<SaveData> FindAsync(string key)
        {
            var name = PlayerPrefs.GetString(_nameKey + key, "");
            if (string.IsNullOrEmpty(name)) return default;

            return new SaveData(name);
        }

        public async UniTask StoreAsync(string key, SaveData saveData)
        {
            PlayerPrefs.SetString(_nameKey + key, saveData.Name);
            PlayerPrefs.Save();
        }
    }   
}

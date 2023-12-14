using Prashalt.MusicRun.Model;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer;

namespace Prashalt.MusicRun.Presenter
{
    public class PagePresenter : MonoBehaviour
    {
        private SaveDataManager _saveDataManager;
        private MainScreenPageManager _mainScreenPageManager;
        [SerializeField] private PageContainer pageContainer;
        
        [Inject]
        public void Constructor(SaveDataManager saveDataManager, MainScreenPageManager mainScreenPageManager)
        {
            _saveDataManager = saveDataManager;
            _mainScreenPageManager = mainScreenPageManager;
        }
        private async void Start()
        {
            //セーブデータを読み込む
            await _saveDataManager.FindAsync();
            
            var pageName = await _saveDataManager.GetPageNameBySaveDataStatus();
            _mainScreenPageManager.ChangePage(pageName); 
        }
    }   
}

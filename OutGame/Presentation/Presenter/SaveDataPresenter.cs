using Cysharp.Threading.Tasks;
using Prashalt.MusicRun.Domain;
using Prashalt.MusicRun.Model;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Prashalt.MusicRun.Presenter
{
    public class SaveDataPresenter : MonoBehaviour
    {
        private SaveDataManager _saveDataManager;
        private MainScreenPageManager _mainScreenPageManager;
        [SerializeField] private TMP_InputField nameInputField;

        [SerializeField] private Button saveButton;
        
        [Inject]
        public void Constructor(SaveDataManager saveDataManager, MainScreenPageManager mainScreenPageManager)
        {
            _saveDataManager = saveDataManager;
            _mainScreenPageManager = mainScreenPageManager;
        }
        private void Start()
        {
            saveButton.BindToOnClick(_ =>
            {
                var saveData = new SaveData(nameInputField.text);
                return _saveDataManager.SaveAsync(saveData).ToObservable().ForEachAsync(_ =>
                {
                    _mainScreenPageManager.ChangePage("StartPage");
                });
            });
        }
    }   
}

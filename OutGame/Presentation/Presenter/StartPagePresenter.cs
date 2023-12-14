using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Prashalt.MusicRun.Presenter
{
    public class StartPagePresenter : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        public void Start()
        {
            _startButton.onClick.AddListener(() => EnterStage());
        }

        public void EnterStage()
        {
            //ステージのシーンを読み込み。
            var handle = SceneManager.LoadSceneAsync("Stage");
            handle.allowSceneActivation = false;

            handle.allowSceneActivation = true;
        }
    }   
}

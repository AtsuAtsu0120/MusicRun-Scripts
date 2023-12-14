using System;
using OutGame.Presentation.Model;
using UnityEngine;
using VContainer;

namespace Prashalt.MusicRun.Presenter
{
    public class ShowAudioSpectrumPresenter : MonoBehaviour
    {
        private ShowAudioSpectrumManager _showAudioSpectrumManager;
        [Inject]
        public void Constructer(ShowAudioSpectrumManager showAudioSpectrumManager)
        {
            _showAudioSpectrumManager = showAudioSpectrumManager;
        }
        private void Update()
        {
            var test = _showAudioSpectrumManager.GetAudioSpectrumAverage();
            foreach (var value in test)
            {
                Debug.Log(value);
            }
        }
    }
}
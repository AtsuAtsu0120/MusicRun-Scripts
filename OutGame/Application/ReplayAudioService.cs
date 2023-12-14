using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.SceneManagement;

namespace Prashalt.MusicRun.Application
{
    public class ReplayAudioService
    {
        public IObservable<AudioKey> OnChangePitchEvent => _onChangePitchEvent;
        private readonly Subject<AudioKey> _onChangePitchEvent = new();
        public async UniTask ReplayAudio(IReadOnlyList<AudioKey> audioKeys)
        {
            int i = 0;
            foreach(var key in audioKeys)
            {
                _onChangePitchEvent.OnNext(key);
                
                if (audioKeys.Count - 2 == i)
                {
                    break;
                }
                float waitMiliseconds = (audioKeys[i + 1].Time - audioKeys[i].Time) * 1000;
                
                await UniTask.Delay((int)waitMiliseconds);
                i++;
            }
            //ピッチを0にして音を止める。
            _onChangePitchEvent.OnNext(new AudioKey(0, 0, 0));

            await UniTask.Delay(1000);
            SceneManager.LoadSceneAsync("StartScreen");
        }
    }
    public struct AudioKey
    {
        public AudioKey(float audioTime = 0, int pitch = 1, float time = 0) {
            AudioTime = audioTime;
            Pitch = pitch;
            Time = time;
        }

        public override string ToString()
        {
            return $"AudioTime:{AudioTime}, Pitch:{Pitch}";
        }

        public float AudioTime { get; internal set; }
        public float Time { get; }
        public int Pitch { get; internal set; }
    }
}
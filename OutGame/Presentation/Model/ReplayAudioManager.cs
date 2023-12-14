using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Prashalt.MusicRun.Application;
using UnityEngine;
using VContainer;
using UniRx;

namespace OutGame.Presentation
{
    public class ReplayAudioManager
    {
        
        private readonly ReplayAudioService _replayAudioService;
        private readonly AudioSource _audioSource;
        [Inject]
        public ReplayAudioManager(ReplayAudioService replayAudioService, AudioSource audioSource)
        {
            _replayAudioService = replayAudioService;
            _audioSource = audioSource;
            
            _replayAudioService.OnChangePitchEvent.Subscribe(SetAudioSourceParameter);
        }

        private void SetAudioSourceParameter(AudioKey key)
        {
            _audioSource.pitch = key.Pitch;
            _audioSource.time = key.AudioTime;
        }
        
        public async UniTask ReplayAudio(IReadOnlyList<AudioKey> audioKeys)
        {
            _audioSource.time = 0.01f;
            await _replayAudioService.ReplayAudio(audioKeys);
        }
    }
}
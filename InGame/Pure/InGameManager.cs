using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using InGame.View;
using OutGame.Presentation;
using Prashalt.MusicRun.Application;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Prashalt.MusicRun.InGame.Pure
{
    public class InGameManager
    {
        public IObservable<Unit> OnJoinInGameObservable => _onJoinInGameObservable;
        
        private readonly Subject<Unit> _onJoinInGameObservable = new();
        private readonly Start _start;
        private readonly CharacterController2D _player;
        private readonly AudioSource _audioSource;
        private readonly ReplayAudioManager _replayAudioManager;
        private readonly List<AudioKey> _audioKeys = new();
        
        [Inject]
        public InGameManager(Start start, CharacterController2D player, AudioSource audioSource, ReplayAudioManager replayAudioManager)
        {
            _start = start;
            _player = player;
            _audioSource = audioSource;
            _replayAudioManager = replayAudioManager;
            
            _onJoinInGameObservable.OnNext(Unit.Default);

            Observable.EveryUpdate().Subscribe(
                _ =>
                {
                    //トランスフォームの計算をする
                    var subtract = _player.transform.position.x - _player.previousFramePositionX;

                    //座標によって逆再生の有無を変更
                    var nowPitch = _audioSource.pitch;
                    if (subtract < 0.005 && subtract > -0.005)
                    {
                        _audioSource.pitch = 0;
                    }
                    else if (subtract < 0.01 && _audioSource.time > 0.1f)
                    {
                        _audioSource.pitch = -1;
                    }
                    else if (subtract > 0.01)
                    {
                        _audioSource.pitch = 1;
                    }
                    else
                    {
                        _audioSource.pitch = 0;
                    }

                    //もし現在のピッチが変更になった場合はその時間とピッチを保存しておく。
                    if (Math.Abs(nowPitch - _audioSource.pitch) > 0)
                    {
                        var audioKey = new AudioKey(_audioSource.time, (int)_audioSource.pitch, Time.time);
                        AddAudioKey(audioKey);
                    }

                    _player.previousFramePositionX = _player.transform.position.x;
                }
            ).AddTo(_player);
        }

        internal void ResetPosition()
        {
            _player.transform.position = _start.transform.position;
            _audioSource.time = 0.0f;
        }
        
        internal async void OnEndGame()
        {
            //TODO: シーン間通信
            SceneManager.LoadSceneAsync("PlaySound");
            await UniTask.Delay(100);
            await _replayAudioManager.ReplayAudio(_audioKeys);
        }
        private void AddAudioKey(AudioKey key)
        {
            _audioKeys.Add(key);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Prashalt.MusicRun.Application;
using UnityEngine;
using VContainer;

namespace OutGame.Presentation.Model
{
    public class ShowAudioSpectrumManager
    {
        private const int AudioSpectrumNum = 8;
        private float[] _spectrum = new float[256];
        
        private readonly AudioSource _audioSource;
        
        [Inject]
        public ShowAudioSpectrumManager(ReplayAudioService replayAudioService, AudioSource audioSource)
        {
            _audioSource = audioSource;
        }
        private float[] GetAudioSpectrum()
        {
            _audioSource.GetSpectrumData(_spectrum, 0, FFTWindow.Rectangular);

            return _spectrum;
        }

        public IEnumerable<float> GetAudioSpectrumAverage()
        {
            var spectrum = GetAudioSpectrum();
            
            var spectrumChunks = spectrum.Select((v, i) => new { v, i })
                .GroupBy(x => x.i / AudioSpectrumNum)
                .Select(g => g.Select(x => x.v));

            foreach (var chunk in spectrumChunks)
            {
                var sum = 0.0f;
                foreach (var value in chunk)
                {
                    sum += value;
                }

                var ave = sum / chunk.Count();
                yield return ave;
            }
        }
    }
}
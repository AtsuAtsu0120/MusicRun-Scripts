using OutGame.Presentation;
using Prashalt.MusicRun.Application;
using UnityEngine;
using VContainer;
using VContainer.Unity;


public class PlaySoundLifetimeScope : LifetimeScope
{
    [SerializeField] private AudioSource _audioSource;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ReplayAudioService>(Lifetime.Singleton);
        builder.Register<ReplayAudioManager>(Lifetime.Singleton);

        builder.RegisterComponent(_audioSource);
    }
}
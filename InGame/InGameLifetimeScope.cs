using InGame.View;
using OutGame.Presentation;
using Prashalt.MusicRun.Application;
using Prashalt.MusicRun.InGame.Pure;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame
{
    public class InGameLifetimeScope : LifetimeScope
    {
        [SerializeField] private Start start;
        [SerializeField] private CharacterController2D player;
        [SerializeField] private AudioSource audioSource;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InGameManager>(Lifetime.Singleton);
            builder.Register<ReplayAudioManager>(Lifetime.Singleton);
            builder.Register<ReplayAudioService>(Lifetime.Singleton);
            
            builder.RegisterComponent(start);
            builder.RegisterComponent(player);
            builder.RegisterComponent(audioSource);
        }
    }
}
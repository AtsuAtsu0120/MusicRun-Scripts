using Prashalt.MusicRun.Application;
using Prashalt.MusicRun.Domain;
using Prashalt.MusicRun.Infrastructure;
using Prashalt.MusicRun.Model;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using VContainer;
using VContainer.Unity;

public class MainLobbyLifetimeScope : LifetimeScope
{
    [SerializeField] private PageContainer pageContainer;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SaveDataManager>(Lifetime.Singleton);
        builder.Register<SaveDataService>(Lifetime.Singleton);
        builder.Register<ISaveDataRepository, PlayerPrefsSaveDataRepository>(Lifetime.Singleton);
        builder.Register<MainScreenPageManager>(Lifetime.Singleton);
        builder.RegisterComponent(pageContainer);

        builder.RegisterEntryPoint<MainScreenPageManager>();
    }
}

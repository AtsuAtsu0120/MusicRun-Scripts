using UnityScreenNavigator.Runtime.Core.Page;
using VContainer;
using VContainer.Unity;

namespace Prashalt.MusicRun.Model
{
    public class MainScreenPageManager : IInitializable
    {
        private readonly PageContainer _miniPageContainer;
        private readonly IObjectResolver _resolver;

        [Inject]
        public MainScreenPageManager(PageContainer miniPageContainer, IObjectResolver resolver)
        {
            _miniPageContainer = miniPageContainer;
            _resolver = resolver;
        }

        public void Initialize()
        {
            _miniPageContainer.AddCallbackReceiver(new VContainerPageCallbackRegister(_resolver));
        }
        public void ChangePage(string pageName)
        {
            _miniPageContainer.Push(pageName, true);
        }
    }
}
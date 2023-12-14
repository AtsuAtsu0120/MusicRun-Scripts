using UnityScreenNavigator.Runtime.Core.Page;
using VContainer;
using VContainer.Unity;

namespace Prashalt.MusicRun.Model
{
    public class VContainerPageCallbackRegister : IPageContainerCallbackReceiver
    {
        private readonly IObjectResolver _resolver;
        public VContainerPageCallbackRegister(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        public void BeforePush(Page enterPage, Page exitPage)
        {
            _resolver.InjectGameObject(enterPage.gameObject);
        }

        public void AfterPush(Page enterPage, Page exitPage)
        {
            
        }

        public void BeforePop(Page enterPage, Page exitPage)
        {
            _resolver.InjectGameObject(enterPage.gameObject);
        }

        public void AfterPop(Page enterPage, Page exitPage)
        {
            
        }
    }
}
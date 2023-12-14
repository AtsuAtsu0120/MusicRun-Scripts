using Prashalt.MusicRun.InGame.Pure;
using VContainer;

namespace Prashalt.MusicRun.InGame.View
{
    public class FallArea : Area
    {
        private InGameManager _inGameManager;
        
        [Inject]
        public void Constracuter(InGameManager inGameManager)
        {
            _inGameManager = inGameManager;
        }
        protected override void OnTriggerEnterPlayer()
        {
            _inGameManager.ResetPosition();
        }
    }
}
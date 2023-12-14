using System;
using InGame.View;
using Prashalt.MusicRun.InGame.Pure;
using UnityEngine;
using VContainer;

namespace Prashalt.MusicRun.InGame.View
{
    public class GoalArea : Area
    {
        [SerializeField] CharacterController2D player;

        private InGameManager _inGameManager;
        
        [Inject]
        public void Constructer(InGameManager inGameManager)
        {
            _inGameManager = inGameManager;
        }
        protected override void OnTriggerEnterPlayer()
        {
            player.goalFlag.Value = true;
            _inGameManager.OnEndGame();
        }

        #region forUnityEditor

        private void Reset()
        {
            if (!player)
            {
                var isFound = GameObject.FindWithTag("Player").TryGetComponent<CharacterController2D>(out var component);
                player = isFound ? component : null;
            }
        }
        
        #endregion
    }
}
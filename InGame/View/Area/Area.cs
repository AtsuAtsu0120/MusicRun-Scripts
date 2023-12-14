using System;
using UnityEngine;

namespace Prashalt.MusicRun.InGame.View
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Area : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnTriggerEnterPlayer();
            }
        }

        protected abstract void OnTriggerEnterPlayer();
    }
}
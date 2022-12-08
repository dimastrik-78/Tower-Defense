using System;
using UnityEngine;

namespace BuildSystem
{
    public class BuildTower : MonoBehaviour
    {
        public static event Action<Transform, Collider> OnSelectBuildZone;
        
        [SerializeField] private Transform spawnPoint;

        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnMouseDown()
        {
            OnSelectBuildZone?.Invoke(spawnPoint, _collider);
        }
    }
}

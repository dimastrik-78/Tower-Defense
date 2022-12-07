using System;
using TowerSystem;
using UnityEngine;

namespace BuildSystem
{
    public class BuildTower : MonoBehaviour
    {
        public static event Action<Transform> OnSelectBuildZone;
        
        [SerializeField] private GameObject panelBuildTower;

        private TowerSO _towerSo;
        private Transform _spawnPoint;

        private void Start()
        {
            _towerSo = Resources.Load<TowerSO>("People");
            
            _spawnPoint = gameObject.transform;
        }
        
        private void OnMouseUp()
        {
            Debug.Log("test");
            panelBuildTower.SetActive(true);
            
            OnSelectBuildZone?.Invoke(_spawnPoint);
        }
    }
}

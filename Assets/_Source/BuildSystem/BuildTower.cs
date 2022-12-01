using System;
using _Source.TowerSystem;
using UnityEngine;

namespace _Source.BuildSystem
{
    public class BuildTower : MonoBehaviour
    {

        private GameObject _panelBuildTower;
        private PeopleSO _peopleSo;
        private Transform _spawnPoint;

        private void Start()
        {
            _peopleSo = Resources.Load<PeopleSO>("People");
            _panelBuildTower = gameObject.transform.GetChild(0).gameObject;
            _spawnPoint = gameObject.transform;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _panelBuildTower.SetActive(false);
            }
        }

        private void OnMouseDown()
        {
            _panelBuildTower.SetActive(true);
        }

        public void Build()
        {
            Instantiate(_peopleSo.weaponPrefab, _spawnPoint);
        }
    }
}

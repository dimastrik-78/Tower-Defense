using System;
using BuildSystem;
using MaterialSystem;
using TowerSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Text textStone;
        [SerializeField] private Text textFlesh;
        
        private Transform _spawnPoint;
        private TowerSO _towerSo;
        private Upgrade _upgrade;

        private void Start()
        {
            _upgrade = new Upgrade();
        }

        private void ChangeMaterials(int stone, int flesh)
        {
            textStone.text = stone.ToString();
            textFlesh.text = flesh.ToString();
        }
        
        private void OnEnable()
        {
            BuildTower.OnSelectBuildZone += Settings;
            ResourcesBank.OnChangeMaterial += ChangeMaterials;
        }

        private void OnDisable()
        {
            BuildTower.OnSelectBuildZone -= Settings;
            ResourcesBank.OnChangeMaterial -= ChangeMaterials;
        }

        private void Settings(Transform spawnPoint)
        {
            _spawnPoint = spawnPoint;
        }
        
        public void BuildArcherTower()
        {
            _towerSo = Resources.Load<TowerSO>("Archer");
            if (int.Parse(textStone.text) >= _towerSo.BuildCost)
            {
                Instantiate(_towerSo.LevelView[0], _spawnPoint).GetComponent<TowerBase>().Upgrade = _upgrade;
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(-_towerSo.BuildCost, 0);
                    
                panel.SetActive(false);
            }
        }
        
        public void BuildSpearmanTower()
        {
            _towerSo = Resources.Load<TowerSO>("Spearman");
            if (int.Parse(textStone.text) >= _towerSo.BuildCost)
            {
                Instantiate(_towerSo.LevelView[0], _spawnPoint).GetComponent<TowerBase>().Upgrade = _upgrade;
                    
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(-_towerSo.BuildCost, 0);
                
                panel.SetActive(false);
            }
        }
        
        public void BuildCatapultTower()
        {
            _towerSo = Resources.Load<TowerSO>("Catapult");
            if (int.Parse(textStone.text) >= _towerSo.BuildCost)
            {
                Instantiate(_towerSo.LevelView[0], _spawnPoint).GetComponent<TowerBase>().Upgrade = _upgrade;
                    
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(-_towerSo.BuildCost, 0);
                    
                panel.SetActive(false);
            }
        }
    }
}

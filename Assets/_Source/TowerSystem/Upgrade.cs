using ResourcesSystem;
using TMPro;
using UnityEngine;

namespace TowerSystem
{
    public class Upgrade : MonoBehaviour
    {
        [SerializeField] private GameObject buildUI;
        [SerializeField] private GameObject upgradePanel;
        [SerializeField] private TextMeshProUGUI[] textUpgrade;
        
        private TowerSO _towerSO;
        private TowerBase _towerBase;
        private int _stone;
        private int _bone;

        public Upgrade()
        {
            ResourcesBank.OnChangeMaterial += ChangeMaterials;
        }

        private void ChangeMaterials(int stone, int bone)
        {
            _stone = stone;
            _bone = bone;
        }

        public void Settings(TowerSO towerSO, TowerBase towerBase)
        {
            _towerSO = towerSO;
            _towerBase = towerBase;
            
            upgradePanel.SetActive(true);
            buildUI.SetActive(false);

            textUpgrade[0].text = _towerSO.UpgradeCostStone[_towerBase.LevelTower - 1].ToString();
            textUpgrade[1].text = _towerSO.UpgradeCostBone[_towerBase.LevelTower - 1].ToString();
        }
        
        public void Up()
        {
            if (_stone >= _towerSO.UpgradeCostStone[_towerBase.LevelTower - 1]
                && _bone >= _towerSO.UpgradeCostBone[_towerBase.LevelTower - 1])
            {
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(-_towerSO.UpgradeCostStone[_towerBase.LevelTower - 1], -_towerSO.UpgradeCostBone[_towerBase.LevelTower - 1]);
                
                _towerBase.LevelTower++;
                _towerBase.Damage += _towerSO.UpgradeDamage;
                _towerBase.SpeedAttack += _towerSO.UpgradeAttackSpeed;
                _towerBase.MeshFilter.mesh = _towerSO.LevelView[_towerBase.LevelTower - 1];
            }
            
            upgradePanel.SetActive(false);
        }
    }
}

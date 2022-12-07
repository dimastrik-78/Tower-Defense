using MaterialSystem;
using UnityEngine;

namespace TowerSystem
{
    public class Upgrade
    {
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
        
        public void Up(TowerSO towerSO, TowerBase towerBase)
        {
            if (_stone >= towerSO.UpgradeCostStone[towerBase.LevelTower]
                && _bone >= towerSO.UpgradeCostBone[towerBase.LevelTower])
            {
                towerBase.LevelTower++;
                towerBase.Damage += towerSO.UpgradeDamage;
                towerBase.SpeedAttack += towerSO.UpgradeAttackSpeed;
                towerBase.MeshFilter.mesh = towerSO.LevelView[towerBase.LevelTower];
                
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(-towerSO.UpgradeCostStone[towerBase.LevelTower], -towerSO.UpgradeCostBone[towerBase.LevelTower]);
            }
        }
    }
}

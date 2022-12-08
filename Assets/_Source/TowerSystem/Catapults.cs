using BulletSystem;
using UnityEngine;

namespace TowerSystem
{
    public class Catapults : TowerBase
    {
        private TowerSO _towerSo;

        protected override void Start()
        {
            base.Start();
            
            _towerSo = Resources.Load<TowerSO>("Catapults");

            AttackRadius.radius = _towerSo.AttackRadius;
            ProjectilePrefab = _towerSo.ProjectilePrefab;
            SpeedAttack = _towerSo.SpeedAttack;
            Damage = _towerSo.Damage;
            MeshFilter.mesh = _towerSo.LevelView[0];
        }

        protected override void Update()
        {
            base.Update();
            Timer();
        }
        
        private void Timer()
        {
            if (EnemyList.Count > 0)
            {
                SpeedAttack -= Time.deltaTime;
                
                if (SpeedAttack <= 0)
                {
                    Instantiate(ProjectilePrefab, spawnPoint).GetComponent<CatapultProjectile>().GettingCharacteristics(Damage);
                    
                    SpeedAttack = _towerSo.SpeedAttack;
                }
            }
            else
            {
                SpeedAttack = _towerSo.SpeedAttack;
            }
        }
        
        private void OnMouseDown()
        {
            if (LevelTower < 3)
                Upgrade.Settings(_towerSo, this);
        }
    }
}

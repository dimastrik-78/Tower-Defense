using System.Collections.Generic;
using EnemySystem;
using UnityEngine;

namespace TowerSystem
{
    public abstract class TowerBase : MonoBehaviour
    {
        [SerializeField] protected GameObject upgradePanel;
        [SerializeField] protected LayerMask enemyLayer;
        [SerializeField] protected Transform spawnPoint;

        public Upgrade Upgrade;
        [HideInInspector] public int LevelTower;
        [HideInInspector] public MeshFilter MeshFilter;
        [HideInInspector] public double SpeedAttack;
        [HideInInspector] public int Damage;
        
        protected SphereCollider AttackRadius;
        protected List<GameObject> EnemyList = new();
        protected GameObject ProjectilePrefab;

        protected virtual void Start()
        {
            gameObject.transform.parent = null;

            AttackRadius = GetComponent<SphereCollider>();
            MeshFilter = GetComponent<MeshFilter>();
            LevelTower = 1;
        }
        
        protected virtual void Update()
        {
            if (EnemyList.Count > 0)
            {
                gameObject.transform.GetChild(0).LookAt(EnemyList[0].transform);
            }
        }
        
        protected void DeleteEnemyFromList(GameObject enemy)
        {
            EnemyList.Remove(enemy);
            
            enemy.GetComponent<Enemy>().OnDeadOneAction -= DeleteEnemyFromList;
        }
        
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
            { 
                EnemyList.Add(other.gameObject);
                
                other.GetComponent<Enemy>().OnDeadOneAction += DeleteEnemyFromList;
            }
        }
        
        protected void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == 7)
                DeleteEnemyFromList(other.gameObject);
        }
    }
}

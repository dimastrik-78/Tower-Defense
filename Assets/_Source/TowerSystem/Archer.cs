using System.Collections.Generic;
// using _Source.EnemySystem;
using UnityEngine;

namespace _Source.TowerSystem
{
    public class Archer : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayer;
        // [SerializeField] private GameObject weaponPrefab; 
        [SerializeField] private Transform spawnPoint;
        // [SerializeField] private float speedAttack;
        // [SerializeField] private int damage;
        // [SerializeField] private float attackRadius;
        
        private PeopleSO _peopleSo;
        private GameObject _projectilePrefab;
        private TimeControl _timeControl;
        private SphereCollider _triggerZone;
        private List<GameObject> _enemyList;
        private float _speedAttackTime;

        private void Start()
        {
            gameObject.transform.parent = null;
            
            _peopleSo = Resources.Load<PeopleSO>("People");
            
            _timeControl = new TimeControl();
            _enemyList = new List<GameObject>();
            
            _triggerZone = GetComponent<SphereCollider>();
            _projectilePrefab = _peopleSo.projectilePrefab;
            _triggerZone.radius = _peopleSo.attackRadius;

            _speedAttackTime = _peopleSo.speedAttack;
        }

        private void Update()
        {
            if (_enemyList.Count > 0)
                gameObject.transform.LookAt(_enemyList[0].transform);

            Timer();
        }

        private void LookAtEnemy()
        {
            
        }
        
        private void Timer()
        {
            _speedAttackTime -= Time.deltaTime;
            if (_speedAttackTime <= 0)
            {
                Instantiate(_projectilePrefab, spawnPoint);
                _speedAttackTime = _peopleSo.speedAttack;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == enemyLayer)
                _enemyList.Add(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == enemyLayer)
                _enemyList.Remove(other.gameObject);
        }
    }
}

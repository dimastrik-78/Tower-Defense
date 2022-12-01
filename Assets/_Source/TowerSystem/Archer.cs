using System;
using System.Collections.Generic;
// using _Source.EnemySystem;
using UnityEngine;

namespace _Source.TowerSystem
{
    public class Archer : MonoBehaviour
    {
        [SerializeField] private GameObject weaponPrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float speedAttack;
        [SerializeField] private int damage;
        [SerializeField] private float attackRadius;

        private PeopleSO _peopleSo;
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
            _triggerZone.radius = _peopleSo.attackRadius;

            _speedAttackTime = _peopleSo.speedAttack;
        }

        private void Update()
        {
            if (_enemyList.Count > 0)
                gameObject.transform.LookAt(_enemyList[0].transform);

            // if (_timeControl.Timer(ref _speedAttackTime))
        }

        private void OnTriggerEnter(Collider other)
        {
            _enemyList.Add(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            _enemyList.Remove(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace _Source.EnemySystem
{
    
    public class ArmoredExplosive : MonoBehaviour
    {
        //public static Action<int> OnGettingDamage;

        private EnemyMovement enemyMovement;
        
        [SerializeField] private Transform enemyPosition;
        [SerializeField] private float speed;
        [SerializeField] private List<Transform> wayPoints;
        [SerializeField] private int healthPoint;
        [SerializeField] private float attackSpeed;
        [SerializeField] private int damage;

        private int _currentWayPoint;

        private void Update()
        {
            if (_currentWayPoint < wayPoints.Count)
            {
                enemyMovement.Movement(enemyPosition, speed, wayPoints[_currentWayPoint]);
                if (gameObject.transform.position == wayPoints[_currentWayPoint].position && _currentWayPoint < wayPoints.Count)
                {
                    _currentWayPoint++;
                }
            }
            //if(_currentWayPoint == wayPoints.Count)
            //{
            //    OnGettingDamage = DoDamage;
            //}
        }

        private void Spawn(List<Transform> wayPoint)
        {
            wayPoints = wayPoint;
            enemyMovement = new EnemyMovement();
            _currentWayPoint = 0;
            enemyPosition.LookAt(wayPoints[_currentWayPoint]);
            EnemyWave.OnChangeState -= Spawn;
            
        }

        //private void DoDamage(int healthPoints)
        //{
        //    if (_currentWayPoint == wayPoints.Count)
        //    {
        //        healthPoints -= damage;
        //    }
        //}
        private void OnEnable()
        {
            EnemyWave.OnChangeState += Spawn;
        }

    }
}



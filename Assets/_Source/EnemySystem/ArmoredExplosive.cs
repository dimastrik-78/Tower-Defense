using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.EnemySystem
{
    public class ArmoredExplosive : MonoBehaviour
    {
        private EnemyMovement enemyMovement;
        
        [SerializeField] private Transform enemyPosition;
        [SerializeField] private float speed;
        [SerializeField] private List<Transform> wayPoints;

        private int currentWayPoint = -1;

        private void Update()
        {
            if (currentWayPoint < wayPoints.Count) enemyMovement.Movement(enemyPosition, speed, wayPoints[currentWayPoint]);

            if (currentWayPoint < wayPoints.Count && gameObject.transform.position == wayPoints[currentWayPoint].position)
            {
                currentWayPoint++;
                enemyPosition.LookAt(wayPoints[currentWayPoint]);
            }
            //else if (currentWayPoint >= wayPoints.Count)
            //{
            //    Destroy(gameObject);
            //}
        }

        private void Spawn(List<Transform> wayPoint)
        {
            wayPoints = wayPoint;
            enemyMovement = new EnemyMovement();
            currentWayPoint = 0;
            enemyPosition.LookAt(wayPoints[currentWayPoint]);
            EnemyWave.OnChangeState -= Spawn;
            Debug.Log(wayPoint.Count);
            Debug.Log(wayPoints.Count);
            
        }
        private void OnEnable()
        {
            EnemyWave.OnChangeState += Spawn;
        }
    }
}



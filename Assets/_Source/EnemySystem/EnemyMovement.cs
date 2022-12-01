using UnityEngine;

namespace _Source.EnemySystem
{
    public class EnemyMovement
    {
        public void Movement(Transform enemyPosition, float speed, Transform wayPoint)
        {
            enemyPosition.transform.position = Vector3.MoveTowards(enemyPosition.position, wayPoint.position, speed/10 * Time.deltaTime);
            enemyPosition.LookAt(wayPoint);
        }
    }
}

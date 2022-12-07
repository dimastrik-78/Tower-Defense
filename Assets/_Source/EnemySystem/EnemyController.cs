using UnityEngine;

namespace EnemySystem
{
    public class EnemyController
    {
        public void Movement(Transform enemyPosition, float speed, Transform wayPoint)
        {
            enemyPosition.transform.position = Vector3.MoveTowards(enemyPosition.position, wayPoint.position, speed * Time.deltaTime);
        }

        public void Look(Transform enemyPosition, Transform lookPosition)
        {
            enemyPosition.LookAt(lookPosition);
        }
    }
}

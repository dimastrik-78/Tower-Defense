using UnityEngine;

namespace _Source.TowerSystem
{
    [CreateAssetMenu(fileName = "People", menuName = "TowerDefense/People")]
    public class PeopleSO : ScriptableObject
    {
        public GameObject projectilePrefab;
        public int cost;
        public int damage;
        public float speedAttack;
        public float attackRadius;
    }
}

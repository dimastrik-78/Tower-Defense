using UnityEngine;

namespace _Source.TowerSystem
{
    [CreateAssetMenu(fileName = "People", menuName = "TowerDefense/People")]
    public class PeopleSO : ScriptableObject
    {
        public GameObject weaponPrefab;
        // public Transform spawnPoint;
        public float speedAttack;
        public int damage;
        public float attackRadius;
    }
}

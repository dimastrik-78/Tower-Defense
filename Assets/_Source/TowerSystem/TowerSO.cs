using UnityEngine;

namespace TowerSystem
{
    [CreateAssetMenu(fileName = "People", menuName = "TowerDefense/People")]
    public class TowerSO : ScriptableObject
    {
        [SerializeField] private GameObject towerBase;
        [SerializeField] private Mesh[] levelView;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int buildBuildCost;
        [SerializeField] private int[] upgradeCostCost;
        [SerializeField] private int[] upgradeCostBone;
        [SerializeField] private int upgradeDamage;
        [SerializeField] private float upgradeAttackSpeed;
        [SerializeField] private int damage;
        [SerializeField] private float speedAttack;
        [SerializeField] private float attackRadius;
        
        public GameObject TowerBase { get => towerBase; }
        public Mesh[] LevelView { get => levelView; }
        public GameObject ProjectilePrefab { get => projectilePrefab; }
        public int BuildCost { get => buildBuildCost; }
        public int[] UpgradeCostStone { get => upgradeCostCost; }
        public int[] UpgradeCostBone { get => upgradeCostBone; }
        public int UpgradeDamage { get => upgradeDamage; }
        public float UpgradeAttackSpeed { get => upgradeAttackSpeed; }
        public int Damage { get => damage; }
        public float SpeedAttack { get => speedAttack; }
        public float AttackRadius { get => attackRadius; }

    }
}

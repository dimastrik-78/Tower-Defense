using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem
{
    [CreateAssetMenu(fileName = "People", menuName = "TowerDefense/People")]
    public class TowerSO : ScriptableObject
    {
        [SerializeField] private GameObject towerBase;
        [SerializeField] private Mesh[] levelView;
        [SerializeField] private Sprite[] levelViewSprite;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int buildBuildCost;
        [SerializeField] private int[] upgradeCostStone;
        [SerializeField] private int[] upgradeCostBone;
        [SerializeField] private int upgradeDamage;
        [SerializeField] private float upgradeAttackSpeed;
        [SerializeField] private int damage;
        [SerializeField] private float speedAttack;
        [SerializeField] private float attackRadius;
        
        public GameObject TowerBase { get => towerBase; }
        public Mesh[] LevelView { get => levelView; }
        public Sprite[] LevelViewSprite { get => levelViewSprite; }
        public GameObject ProjectilePrefab { get => projectilePrefab; }
        public int BuildCost { get => buildBuildCost; }
        public int[] UpgradeCostStone { get => upgradeCostStone; }
        public int[] UpgradeCostBone { get => upgradeCostBone; }
        public int UpgradeDamage { get => upgradeDamage; }
        public float UpgradeAttackSpeed { get => upgradeAttackSpeed; }
        public int Damage { get => damage; }
        public float SpeedAttack { get => speedAttack; }
        public float AttackRadius { get => attackRadius; }

    }
}

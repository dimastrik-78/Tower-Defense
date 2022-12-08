using System;
using Interface;
using ResourcesSystem;
using UnityEngine;
using UnityEngine.UI;

namespace EnemySystem
{
    public class Enemy : MonoBehaviour, IDamage
    {
        public static event Action<int> OnDealingDamage;
        public Action<GameObject> OnDeadOneAction;
        public static event Action<bool> OnDeadTwoAction;

        [SerializeField] private Slider heal;
        [SerializeField] private int extraditionBone;
        [SerializeField] private int healthPoint;
        [SerializeField] private float speed;
        [SerializeField] private int damage;

        private EnemyController _enemyController;
        private Transform _enemyPosition;
        private Transform[] _wayPoints;
        private int _currentWayPoint;
        
        protected void Awake()
        {
            _enemyController = new EnemyController();
            
            _enemyPosition = gameObject.transform;
            _currentWayPoint = 0;

            heal.maxValue = healthPoint;
            heal.value = healthPoint;
        }
        
        protected void Update()
        {
            _enemyController.Movement(_enemyPosition, speed, _wayPoints[_currentWayPoint]);
            
            if (gameObject.transform.position == _wayPoints[_currentWayPoint].position && _currentWayPoint < _wayPoints.Length)
            {
                _currentWayPoint++;
                    
                if(_currentWayPoint == _wayPoints.Length)
                {
                    OnDealingDamage?.Invoke(damage);
                    OnDeadTwoAction?.Invoke(false);
                        
                    Destroy(gameObject);
                    return;
                }
                    
                _enemyController.Look(_enemyPosition, _wayPoints[_currentWayPoint]);
            }
        }

        private void Spawn(Transform[] wayPoint)
        {
            _wayPoints = wayPoint;
            _currentWayPoint = 0;
            _enemyController.Look(_enemyPosition, _wayPoints[_currentWayPoint]);
            
            EnemyWave.OnChangeState -= Spawn;
        }

        private void CheckHeal()
        {
            if (healthPoint <= 0)
            {
                OnDeadOneAction?.Invoke(gameObject);
                OnDeadTwoAction?.Invoke(true);
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(0, extraditionBone);

                Destroy(gameObject);
            }
        }
        
        protected void OnEnable()
        {
            EnemyWave.OnChangeState += Spawn;
        }
        
        public void TakingDamage(int Damage)
        {
            healthPoint -= Damage;
            heal.value = healthPoint;
        
            CheckHeal();
        }
    }
}

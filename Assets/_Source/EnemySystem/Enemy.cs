using System;
using Interface;
using ResourcesSystem;
using UnityEngine;

namespace EnemySystem
{
    public class Enemy : MonoBehaviour, IDamage
    {
        public static event Action<int> OnDealingDamage;
        public Action<GameObject> OnDeadOneAction;
        public static event Action<bool> OnDeadTwoAction;

        [SerializeField] protected int extraditionBone;
        [SerializeField] protected int healthPoint;
        [SerializeField] protected float speed;
        [SerializeField] protected int damage;

        private EnemyController _enemyController;
        private Transform _enemyPosition;
        private Transform[] _wayPoints;
        private int _currentWayPoint;
        
        protected void Awake()
        {
            _enemyController = new EnemyController();
            
            _enemyPosition = gameObject.transform;
            _currentWayPoint = 0;
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
        
            CheckHeal();
        }
    }
}

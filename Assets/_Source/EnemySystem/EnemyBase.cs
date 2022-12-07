using System;
using MaterialSystem;
using UnityEngine;

namespace EnemySystem
{
    public abstract class EnemyBase : MonoBehaviour, IDamage
    {
        public static event Action<int> OnDealingDamage;
        public Action<GameObject> OnDeadOneAction;
        public static event Action<bool> OnDeadTwoAction;

        [SerializeField] protected int extraditionBone;
        [SerializeField] protected int healthPoint;
        [SerializeField] protected float speed;
        [SerializeField] protected int damage;
        
        protected EnemyController EnemyController;
        protected MeshRenderer Color;
        protected Transform EnemyPosition;
        protected Transform[] WayPoints;
        protected int CurrentWayPoint;
        protected float TimeRedColor = 0.2f;
        protected float Time;
        
        protected void Awake()
        {
            Color = GetComponent<MeshRenderer>();
            EnemyController = new EnemyController();
            
            EnemyPosition = gameObject.transform;
            CurrentWayPoint = 0;
        }
        
        protected void Update()
        {
            if (Color.material.color == UnityEngine.Color.red)
            {
                Timer();
            }
            
            EnemyController.Movement(EnemyPosition, speed, WayPoints[CurrentWayPoint]);
            
            if (gameObject.transform.position == WayPoints[CurrentWayPoint].position && CurrentWayPoint < WayPoints.Length)
            {
                CurrentWayPoint++;
                    
                if(CurrentWayPoint == WayPoints.Length)
                {
                    OnDealingDamage?.Invoke(damage);
                    OnDeadTwoAction?.Invoke(false);
                        
                    Destroy(gameObject);
                    return;
                }
                    
                EnemyController.Look(EnemyPosition, WayPoints[CurrentWayPoint]);
            }
        }
        
        protected void Spawn(Transform[] wayPoint)
        {
            WayPoints = wayPoint;
            CurrentWayPoint = 0;
            EnemyController.Look(EnemyPosition, WayPoints[CurrentWayPoint]);
            
            EnemyWave.OnChangeState -= Spawn;
        }
        
        protected void CheckHeal()
        {
            if (healthPoint <= 0)
            {
                OnDeadOneAction?.Invoke(gameObject);
                OnDeadTwoAction?.Invoke(true);
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(0, extraditionBone);

                Destroy(gameObject);
            }
        }

        protected void Timer()
        {
            Time -= UnityEngine.Time.deltaTime;
            if (Time <= 0)
                Color.material.color = UnityEngine.Color.white;
        }
        
        protected void SwitchColor()
        {
            Color.material.color = UnityEngine.Color.red;
            Time = TimeRedColor;
        }
        protected void OnEnable()
        {
            EnemyWave.OnChangeState += Spawn;
        }
        
        public void TakingDamage(int Damage)
        {
            healthPoint -= Damage;
        
            CheckHeal();
            SwitchColor();
        }
    }
}

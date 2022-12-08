using System;
using EnemySystem;
using Interface;
using UnityEngine;

namespace CaveSystem
{
    public class Cave : MonoBehaviour, IDamage
    {
        public static event Action OnLoseGame;
        public static event Action<int> OnChangeHeal;
        
        [SerializeField] private int healthPoints;

        private void Start()
        {
            OnChangeHeal?.Invoke(healthPoints);
        }

        private void OnEnable()
        {
            Enemy.OnDealingDamage += TakingDamage;
        }

        private void CheckHeal()
        {
            if (healthPoints <= 0)
            {
                Enemy.OnDealingDamage -= TakingDamage;
                
                OnLoseGame?.Invoke();
            }
        }
        
        public void TakingDamage(int Damage)
        {
            healthPoints -= Damage;

            CheckHeal();
            
            OnChangeHeal?.Invoke(healthPoints);
        }
    }
}

using System;
using EnemySystem;
using UnityEngine;

namespace CaveSystem
{
    public class Cave : MonoBehaviour, IDamage
    {
        public static Action OnLoseGame;
        
        [SerializeField] private int healthPoints;

        private void OnEnable()
        {
            EnemyBase.OnDealingDamage += TakingDamage;
        }

        private void CheckHeal()
        {
            if (healthPoints <= 0)
            {
                EnemyBase.OnDealingDamage -= TakingDamage;
                
                OnLoseGame?.Invoke();
            }
        }
        
        public void TakingDamage(int Damage)
        {
            healthPoints -= Damage;

            CheckHeal();
        }
    }
}

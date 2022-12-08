using Interface;
using UnityEngine;
using Random = System.Random;

namespace BulletSystem
{
    public class Spear : ProjectileBase
    {
        private int _towerLevel;
        private Random _random;
        
        protected override void Start()
        {
            _random = new Random();
            
            base.Start();
        }
        
        public void GettingCharacteristics(int damage, int towerLevel)
        {
            base.GettingCharacteristics(damage);
            _towerLevel = towerLevel;
        }
        
        protected override void OnTriggerEnter(Collider other)
        {
            if (_towerLevel >= 3
                && _random.Next(0, 2) == 1)
            {
                other.GetComponent<IDamage>().TakingDamage(999999);
                Destroy(gameObject);
            }
        }
    }
}

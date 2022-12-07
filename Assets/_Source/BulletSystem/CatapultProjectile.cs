using Unity.VisualScripting;
using UnityEngine;

namespace BulletSystem
{
    public class CatapultProjectile : ProjectileBase
    {
        [SerializeField] private int radiusExplosion;
        
        private int _towerLevel;
        private SphereCollider _collider;

        protected override void Start()
        {
            _collider = GetComponent<SphereCollider>();
            
            base.Start();
        }

        public void GettingCharacteristics(int damage, int towerLevel)
        {
            base.GettingCharacteristics(damage);
            _towerLevel = towerLevel;
        }
        
        protected override void OnTriggerEnter(Collider other)
        {
            _collider.radius = radiusExplosion;
            
            base.OnTriggerEnter(other);
        }
    }
}

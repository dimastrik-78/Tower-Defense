using UnityEngine;

namespace BulletSystem
{
    public class CatapultProjectile : ProjectileBase
    {
        [SerializeField] private int radiusExplosion;
        
        private SphereCollider _collider;

        protected override void Start()
        {
            _collider = GetComponent<SphereCollider>();
            
            base.Start();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            _collider.radius = radiusExplosion;
            
            base.OnTriggerEnter(other);
        }
    }
}

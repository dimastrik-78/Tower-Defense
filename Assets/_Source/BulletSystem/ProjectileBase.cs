using System;
using UnityEngine;

namespace BulletSystem
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        [SerializeField] protected LayerMask enemyLayer;
        [SerializeField] protected float speed;
        [SerializeField] protected float startTimeLive;

        protected int Damage;
        protected Rigidbody _rigidbody;
            
        protected virtual void Start()
        {
            gameObject.transform.parent = null;
            
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        protected void Update()
        {
            Timer();
        }

        public void GettingCharacteristics(int damage)
        {
            Damage = damage;
        }
        
        protected void Timer()
        {
            startTimeLive -= Time.deltaTime;
            if (startTimeLive <= 0)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if ((other.gameObject.layer & (1 << enemyLayer.value)) != 0)
            {
                other.GetComponent<IDamage>().TakingDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}

using Interface;
using UnityEngine;

namespace BulletSystem
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        [SerializeField] protected float speed;
        [SerializeField] protected float startTimeLive;

        private int _damage;
        private Rigidbody _rigidbody;
            
        protected virtual void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        protected void Update()
        {
            Timer();
        }

        public void GettingCharacteristics(int damage)
        {
            _damage = damage;
        }

        private void Timer()
        {
            startTimeLive -= Time.deltaTime;
            if (startTimeLive <= 0)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 7)
            {
                other.GetComponent<IDamage>()?.TakingDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}

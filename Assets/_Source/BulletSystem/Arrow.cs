using UnityEngine;

namespace _Source.BulletSystem
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float speed;

        // private GameObject _enemy { get; set; }
        private Rigidbody _rigidbody;
            
        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        void Update()
        {
            // _rigidbody.velocity = new Vector3.mo(0, 3);
            // _rigidbody.velocity = Vector3.MoveTowards();
            // _rigidbodyl.velocity = _rigidbodyl.transform.localRotation;
        }
    }
}

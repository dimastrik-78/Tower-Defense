using UnityEngine;

namespace CameraSystem
{
    public class CameraMovement
    {
        private Rigidbody _rigidbody;
        private int _speed;
        
        public CameraMovement(Rigidbody rigidbody, int speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }
        
        public void Move()
        {
            if (Input.GetAxis("Horizontal") != 0)
                _rigidbody.velocity = new Vector3(-Input.GetAxis("Horizontal") * _speed, 0);
        }
    }
}

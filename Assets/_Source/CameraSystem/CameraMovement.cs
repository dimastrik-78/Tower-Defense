using UnityEngine;

namespace CameraSystem
{
    public class CameraMovement
    {
        private Rigidbody _rigidbody;
        private int _speed;
        private float _leftConstraint;
        private float _rightConstraint;
        
        public CameraMovement(Rigidbody rigidbody, int speed, float leftConstraint, float rightConstraint)
        {
            _rigidbody = rigidbody;
            _speed = speed;
            _leftConstraint = leftConstraint;
            _rightConstraint = rightConstraint;
        }
        
        public void Move()
        {
            if (Input.GetAxis("Horizontal") != 0
                && _rigidbody.transform.position.x >= _leftConstraint
                && _rigidbody.transform.position.x <= _rightConstraint)
            {
                _rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, 0);
            }
            else if(_rigidbody.transform.position.x < _leftConstraint)
            {
                _rigidbody.transform.position = new Vector3(_leftConstraint, _rigidbody.transform.position.y, _rigidbody.transform.position.z);
            }
            else if(_rigidbody.transform.position.x > _rightConstraint)
            {
                _rigidbody.transform.position = new Vector3(_rightConstraint, _rigidbody.transform.position.y, _rigidbody.transform.position.z);
            }
        }
    }
}

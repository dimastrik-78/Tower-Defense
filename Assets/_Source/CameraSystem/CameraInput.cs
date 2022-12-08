using UnityEngine;

namespace CameraSystem
{
    public class CameraInput : MonoBehaviour
    {
        [SerializeField] private int speed;
        [SerializeField] private float leftConstraint;
        [SerializeField] private float rightConstraint;

        private CameraMovement _cameraMovement;
        private Rigidbody _rigidbody;
        
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _cameraMovement = new CameraMovement(_rigidbody, speed, leftConstraint, rightConstraint);
        }

        void Update()
        {
            _cameraMovement.Move();
        }
    }
}

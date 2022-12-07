using UnityEngine;

namespace CameraSystem
{
    public class CameraInput : MonoBehaviour
    {
        [SerializeField] private int speed;
        
        private CameraMovement _cameraMovement;
        private Rigidbody _rigidbody;
        
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _cameraMovement = new CameraMovement(_rigidbody, speed);
        }

        void Update()
        {
            _cameraMovement.Move();
        }
    }
}

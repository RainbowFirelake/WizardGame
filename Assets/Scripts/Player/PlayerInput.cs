using UnityEngine;
using WizardGame.Movables;

namespace WizardGame.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private MovableCharacterController _controllable;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnValidate()
        {
            if (_controllable == null)
            {
                throw new System.Exception("Controllable component in PlayerInput not found!");
            }
        }

        // Update is called once per frame
        void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            var inputVector = new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime;

            var vectorWithCameraRotation = Quaternion.Euler(0, _camera.gameObject.transform.rotation.eulerAngles.y, 0) * inputVector;

            _controllable.Move(vectorWithCameraRotation);
        }
    }
}
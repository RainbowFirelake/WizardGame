using UnityEngine;

namespace WizardGame.Movables
{
    [RequireComponent(typeof(CharacterController))]
    public class MovableCharacterController : MonoBehaviour
    {
        [field: SerializeField]
        public MovableData MovableData { get; private set; }
        [field: SerializeField]
        public CharacterController Controller { get; private set; }

        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        public void Move(Vector3 moveVector)
        {
            Controller.Move(moveVector * MovableData.Speed);
            AlignForwardVectorIfMove(moveVector);
        }

        private void AlignForwardVectorIfMove(Vector3 moveVector)
        {
            if (moveVector != Vector3.zero)
            {
                _transform.forward = moveVector;
            }
        }
    }
}

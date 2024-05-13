using System;
using UnityEngine;

namespace WizardGame.Movables
{
    [RequireComponent(typeof(CharacterController))]
    public class MovableCharacterController : MonoBehaviour
    {
        public event Action<bool> OnMove;

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
            CallMoveEvent(moveVector);

            Controller.Move(moveVector * MovableData.Speed);
            AlignForwardVectorIfMove(moveVector);
            SimulateGravityEffect();
        }

        private void CallMoveEvent(Vector3 moveVector)
        {
            if (moveVector != Vector3.zero)
            {
                OnMove?.Invoke(true);
            }
            else
            {
                OnMove?.Invoke(false);
            }
        }

        private void AlignForwardVectorIfMove(Vector3 moveVector)
        {
            if (moveVector != Vector3.zero)
            {
                _transform.forward = moveVector;
            }
        }

        private void SimulateGravityEffect()
        {
            Controller.Move(new Vector3(0, Physics.gravity.y * Time.deltaTime, 0));
        }
    }
}

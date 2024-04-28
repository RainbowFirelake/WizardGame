using UnityEngine;
using WizardGame.Movables;

[RequireComponent(typeof(MovableCharacterController))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField, HideInInspector]
    private MovableCharacterController _movable;

    private void OnValidate()
    {
        _movable = GetComponent<MovableCharacterController>();
    }

    private void Update()
    {
        SetMoveAnimation();
    }

    private void SetMoveAnimation()
    {
        if (_movable.Controller.velocity != Vector3.zero)
        {
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }
}

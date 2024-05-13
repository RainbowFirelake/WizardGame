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

    private void OnEnable()
    {
        _movable.OnMove += SetMoveAnimation;
    }

    private void OnDestroy()
    {
        _movable.OnMove -= SetMoveAnimation;
    }

    private void SetMoveAnimation(bool flag)
    {
        _animator.SetBool("IsMoving", flag);
    }
}

using UnityEngine;
using WizardGame.Movables;
using Zenject;

[RequireComponent(typeof(MovableCharacterController))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    [SerializeField, HideInInspector]
    private MovableCharacterController _movable;

    [Inject]
    private void Construct(Animator animator)
    {
        _animator = animator;
    }

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

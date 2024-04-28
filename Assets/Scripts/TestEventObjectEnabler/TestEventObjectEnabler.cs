using UnityEngine;
using WizardGame.Common.EventBus;
using WizardGame.Events;

[RequireComponent (typeof(BoxCollider))]
public class TestEventObjectEnabler : MonoBehaviour
{
    [SerializeField]
    private int IdToEnable = 0;
    [SerializeField]
    private Color _color;
    [SerializeField]
    private BoxCollider _boxCollider;

    private void OnValidate()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            EventBus<EnableObjectEvent>.Raise(new EnableObjectEvent
            {
                Id = IdToEnable,
                Level = player.CurrentTestLevel
            });
            player.CurrentTestLevel++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireCube(transform.position, _boxCollider.size);
    }
}

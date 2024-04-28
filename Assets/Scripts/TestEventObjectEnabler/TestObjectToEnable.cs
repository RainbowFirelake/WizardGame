using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WizardGame.Common.EventBus;
using WizardGame.Events;

public class TestObjectToEnable : MonoBehaviour
{
    [SerializeField]
    private int Id = 0;
    [SerializeField]
    private int levelForActivation = 0;
    [SerializeField]
    private GameObject _objectToEnable;

    private EventBinding<EnableObjectEvent> _eventBinding;

    private void OnEnable()
    {
        _eventBinding = new EventBinding<EnableObjectEvent>(HandleEnableEvent);
        EventBus<EnableObjectEvent>.Register(_eventBinding);
    }

    private void HandleEnableEvent(EnableObjectEvent @event)
    {
        if (@event.Level >= levelForActivation && @event.Id == Id)
        {
            _objectToEnable.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    public event UnityAction<Interaction> Exited;

    private Interaction _currentInteraction;

    public bool IsTriggering => _currentInteraction != null;
    public Interaction CurrentInteraction => _currentInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Interaction interaction))
        {
            _currentInteraction = interaction;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Interaction interaction) && interaction.Equals(_currentInteraction))
        {
            _currentInteraction = null;
            Exited?.Invoke(interaction);
        }
    }
}

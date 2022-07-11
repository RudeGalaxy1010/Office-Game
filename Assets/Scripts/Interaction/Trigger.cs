using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    public event UnityAction<PlayerInteraction> Exited;

    private PlayerInteraction _currentInteraction;

    public bool IsTriggering => _currentInteraction != null;
    public PlayerInteraction CurrentInteraction => _currentInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerInteraction interaction))
        {
            _currentInteraction = interaction;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerInteraction interaction) && interaction.Equals(_currentInteraction))
        {
            _currentInteraction = null;
            Exited?.Invoke(interaction);
        }
    }
}

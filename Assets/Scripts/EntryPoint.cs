using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private IncidentManager _incidentManager;

    private void Start()
    {
        _incidentManager.StartCreatingIncidents();
    }
}

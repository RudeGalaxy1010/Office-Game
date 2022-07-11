using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private WorkPlaceManager _incidentManager;
    [SerializeField] private LevelTarget _levelTarget;

    private void Start()
    {
        _levelTarget.Init();
        _incidentManager.Init();
    }
}

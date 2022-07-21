using System.Collections.Generic;
using UnityEngine;

public class WorkPlacesDefeatCondition : Condition
{
    [SerializeField] private WorkPlace[] _workPlaces;
    [SerializeField] private int _maxDiedWorkPlaces;

    private List<WorkPlace> _diedPlaces;

    private void OnEnable()
    {
        foreach (var workPlace in _workPlaces)
        {
            workPlace.Died += OnPlaceDied;
        }
    }

    private void OnDisable()
    {
        foreach (var workPlace in _workPlaces)
        {
            workPlace.Died -= OnPlaceDied;
        }
    }

    private void OnPlaceDied(WorkPlace workPlace)
    {
        if (_diedPlaces.Contains(workPlace))
        {
            return;
        }
        else
        {
            _diedPlaces.Add(workPlace);
        }

        if (_diedPlaces.Count >= _maxDiedWorkPlaces)
        {
            Complete();
        }
    }

    public override void StartTracking()
    {
        _isTracking = true;
    }

    public override void StopTracking()
    {
        _isTracking = false;
    }
}

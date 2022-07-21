using UnityEngine;

public class WorkPlacesDefeatCondition : Condition
{
    [SerializeField] private WorkPlace[] _workPlaces;
    [SerializeField] private int _maxDiedWorkPlaces;

    private int _diedPlaces = 0;

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
        _diedPlaces++;

        if (_diedPlaces >= _maxDiedWorkPlaces)
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

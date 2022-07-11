using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Target : MonoBehaviour
{
    public event UnityAction TargetComplete;
    protected bool _isComplete;
    protected bool _isTracking;

    public bool IsComplete => _isComplete;

    public abstract void StartTracking();
    public abstract void StopTracking();

    public void CompleteTarget()
    {
        StopTracking();
        _isComplete = true;
        TargetComplete?.Invoke();
    }
}

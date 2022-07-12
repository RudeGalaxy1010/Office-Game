using UnityEngine;
using UnityEngine.Events;

public abstract class Condition : MonoBehaviour
{
    public event UnityAction Completed;
    protected bool _isComplete;
    protected bool _isTracking;

    public bool IsComplete => _isComplete;

    public abstract void StartTracking();
    public abstract void StopTracking();

    public void CompleteTarget()
    {
        StopTracking();
        _isComplete = true;
        Completed?.Invoke();
    }
}

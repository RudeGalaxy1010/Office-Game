using UnityEngine;
using UnityEngine.Events;

public abstract class Condition : MonoBehaviour
{
    public event UnityAction Completed;
    protected bool _isCompleted;
    protected bool _isTracking;

    public bool IsCompleted => _isCompleted;

    public abstract void StartTracking();
    public abstract void StopTracking();

    public void Complete()
    {
        StopTracking();
        _isCompleted = true;
        Completed?.Invoke();
    }
}

using UnityEngine;
using UnityEngine.Events;

public abstract class Condition : MonoBehaviour
{
    public event UnityAction Completed;

    public bool IsCompleted { get; protected set; }

    public void Complete()
    {
        enabled = false;
        IsCompleted = true;
        Completed?.Invoke();
    }
}

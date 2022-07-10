using UnityEngine;

[RequireComponent(typeof(WorkPlace))]
public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected WorkPlace Target { get; private set; }

    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    public void Init(WorkPlace target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}

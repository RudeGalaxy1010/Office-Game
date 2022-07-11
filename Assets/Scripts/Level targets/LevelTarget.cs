using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelTarget : MonoBehaviour
{
    public event UnityAction AllTargetsReached;

    [SerializeField] private Target[] _targets;

    private void OnEnable()
    {
        foreach (var target in _targets)
        {
            target.TargetComplete += OnTargetReached;
        }
    }

    private void OnDisable()
    {
        foreach (var target in _targets)
        {
            target.TargetComplete -= OnTargetReached;
        }
    }

    public void Init()
    {
        foreach (var target in _targets)
        {
            target.StartTracking();
        }
    }

    private void OnTargetReached()
    {
        if (_targets.FirstOrDefault(t => t.IsComplete == false))
        {
            return;
        }

        AllTargetsReached?.Invoke();
    }
}

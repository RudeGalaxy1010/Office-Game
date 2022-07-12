using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelTarget : MonoBehaviour
{
    public event UnityAction WinConditionsCompleted;
    public event UnityAction DefeatConditionsCompleted;

    [SerializeField] private Condition[] _winConditions;
    [SerializeField] private Condition[] _defeatConditions;

    private void OnEnable()
    {
        foreach (var condition in _winConditions)
        {
            condition.Completed += OnCompleteWinCondition;
        }

        foreach (var condition in _defeatConditions)
        {
            condition.Completed += OnCompleteDefeatCondition;
        }
    }

    private void OnDisable()
    {
        foreach (var condition in _winConditions)
        {
            condition.Completed -= OnCompleteWinCondition;
        }

        foreach (var condition in _defeatConditions)
        {
            condition.Completed -= OnCompleteDefeatCondition;
        }
    }

    public void Init()
    {
        foreach (var target in _winConditions)
        {
            target.StartTracking();
        }
    }

    private void OnCompleteWinCondition()
    {
        if (_winConditions.FirstOrDefault(t => t.IsComplete == false))
        {
            return;
        }

        WinConditionsCompleted?.Invoke();
    }

    private void OnCompleteDefeatCondition()
    {
        if (_defeatConditions.FirstOrDefault(t => t.IsComplete == true))
        {
            DefeatConditionsCompleted?.Invoke();
        }
    }
}

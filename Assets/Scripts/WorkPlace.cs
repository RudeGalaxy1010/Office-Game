using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WorkPlaceStateMachine))]
public class WorkPlace : MonoBehaviour
{
    public event UnityAction<WorkPlace> IncidentEliminated;
    public event UnityAction<WorkPlace> Died;

    [SerializeField] private float _maxIncidentTime = 60f;
    [SerializeField] private Trigger _trigger;

    private Incident _currentIncident;
    private bool _isEliminating;
    private float _timer;

    public bool IsDied { get; private set; }
    public bool NeedIncident { get; private set; }
    public float MaxIncidentTime => _maxIncidentTime;
    public bool IsIncident => _currentIncident != null;

    private void OnEnable()
    {
        _trigger.Exited += TryEndEliminating;
    }

    private void OnDisable()
    {
        _trigger.Exited -= TryEndEliminating;
    }

    private void Update()
    {
        if (_trigger.IsTriggering)
        {
            TryStartEliminating(_trigger.CurrentInteraction);
        }

        if (_isEliminating)
        {
            _timer += Time.deltaTime;

            if (_timer >= _currentIncident.EliminatingTime)
            {
                EndIncident();
            }
        }
    }

    public bool TryChooseForIncident()
    {
        if (_currentIncident != null)
        {
            return false;
        }

        NeedIncident = true;
        return true;
    }

    public void StartIncident(Incident incident)
    {
        if (_currentIncident != null)
        {
            return;
        }

        NeedIncident = false;
        _currentIncident = incident;
        incident.Enable();
    }

    private void EndIncident()
    {
        if (_currentIncident == null)
        {
            return;
        }

        ResetElimination();
        IncidentEliminated?.Invoke(this);
    }

    public void Die()
    {
        ResetElimination();
        IsDied = true;
        Died?.Invoke(this);
    }

    private void TryStartEliminating(PlayerInteraction interaction)
    {
        if (_currentIncident == null)
        {
            return;
        }

        // TODO: check for right holding object
        _isEliminating = true;
    }

    private void TryEndEliminating(PlayerInteraction interaction)
    {
        if (_currentIncident == null)
        {
            return;
        }

        ResetElimination();
    }

    private void ResetElimination()
    {
        if (_currentIncident == null)
        {
            return;
        }

        _isEliminating = false;
        _timer = 0;
        _currentIncident.Disable();
        _currentIncident = null;
    }
}

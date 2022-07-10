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
        _trigger.Entered += TryStartEliminating;
        _trigger.Exited += TryEndEliminating;
    }

    private void OnDisable()
    {
        _trigger.Entered -= TryStartEliminating;
        _trigger.Exited -= TryEndEliminating;
    }

    private void Update()
    {
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

        _currentIncident = incident;
        incident.Enable();
    }

    private void EndIncident()
    {
        if (_currentIncident == null)
        {
            return;
        }

        _currentIncident.Disable();
        _currentIncident = null;
        _timer = 0;
        IncidentEliminated?.Invoke(this);
    }

    public void Die()
    {
        _currentIncident.Disable();
        _currentIncident = null;
        IsDied = true;
        Died?.Invoke(this);
    }

    private void TryStartEliminating(GameObject player)
    {
        if (_currentIncident == null)
        {
            return;
        }

        // TODO: check for right holding object
        if (player.TryGetComponent(out Interaction interaction))
        {
            _isEliminating = true;
        }
    }

    private void TryEndEliminating(GameObject player)
    {
        if (_currentIncident == null)
        {
            return;
        }

        if (player.TryGetComponent(out Interaction interaction))
        {
            _isEliminating = false;
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WorkPlaceStateMachine))]
public class WorkPlace : MonoBehaviour
{
    public event UnityAction<WorkPlace> IncidentEliminated;
    public event UnityAction<WorkPlace> Died;

    [SerializeField] private float _maxIncidentTime = 60f;
    [SerializeField] private float _maxInteractionDistance = 3f;

    private PlayerInteraction _player;
    private Incident _currentIncident;

    public bool IsDied { get; private set; }
    public bool NeedIncident { get; private set; }
    public float MaxIncidentTime => _maxIncidentTime;
    public float MaxInteractionDistance => _maxInteractionDistance;
    public float EliminatingTime => _currentIncident.EliminatingTime;
    public bool IsIncident => _currentIncident != null;
    public PlayerInteraction Player => _player;

    private void Update()
    {
        if (IsIncident == false)
        {
            return;
        }
    }

    public void Init(PlayerInteraction player)
    {
        _player = player;
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

    public void EndIncident()
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

    private void ResetElimination()
    {
        if (_currentIncident == null)
        {
            return;
        }

        _currentIncident.Disable();
        _currentIncident = null;
    }
}

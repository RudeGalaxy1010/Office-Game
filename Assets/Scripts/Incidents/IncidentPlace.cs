using UnityEngine;

public class IncidentPlace : MonoBehaviour
{
    [SerializeField] private Incident[] _incidents;
    private Incident _currentIncident;

    public bool IsIncident => _currentIncident != null;

    public bool TrySetRandomIncident()
    {
        if (_currentIncident != null)
        {
            return false;
        }

        _currentIncident = _incidents[Random.Range(0, _incidents.Length)];
        _currentIncident.Enable();
        return true;
    }
}

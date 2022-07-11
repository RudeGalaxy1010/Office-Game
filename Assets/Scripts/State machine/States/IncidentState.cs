using UnityEngine;

public class IncidentState : State
{
    [SerializeField] private Incident[] _incidents;
    private float _timer;

    private void OnEnable()
    {
        if (Target.IsIncident == false)
        {
            _timer = 0;
            Target.StartIncident(_incidents[Random.Range(0, _incidents.Length)]);
        }
    }

    private void OnDisable()
    {

    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= Target.MaxIncidentTime)
        {
            Target.Die();
        }   
    }
}

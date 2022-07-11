using UnityEngine;
using UnityEngine.UI;

public class IncidentState : State
{
    [SerializeField] private Incident[] _incidents;
    [SerializeField] private Slider _progressBar;
    private float _timer;

    private void OnEnable()
    {
        if (Target.IsIncident == false)
        {
            _timer = 0;
            Target.StartIncident(_incidents[Random.Range(0, _incidents.Length)]);
        }

        _progressBar.maxValue = Target.MaxIncidentTime;
        _progressBar.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _progressBar.gameObject.SetActive(false);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _progressBar.value = _timer;

        if (_timer >= Target.MaxIncidentTime)
        {
            Target.Die();
        }   
    }
}

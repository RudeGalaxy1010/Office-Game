using UnityEngine;
using UnityEngine.UI;

public class EliminatingState : State
{
    private float _timer;
    [SerializeField] private Slider _progressBar;

    private void OnEnable()
    {
        _timer = 0;
        _progressBar.maxValue = Target.EliminatingTime;
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

        if (_timer >= Target.EliminatingTime)
        {
            Target.EndIncident();
        }
    }
}

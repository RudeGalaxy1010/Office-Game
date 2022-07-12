using UnityEngine;
using UnityEngine.UI;

public class TimeWinCondition : Condition
{
    [SerializeField] private float _maxTime;
    [SerializeField] private Slider _progressBar;

    private float _timer;

    private void Update()
    {
        if (_isTracking == false)
        {
            return;
        }

        _timer += Time.deltaTime;
        _progressBar.value = _timer;

        if (_timer >= _maxTime)
        {
            CompleteTarget();
        }
    }

    public override void StartTracking()
    {
        _progressBar.maxValue = _maxTime;
        _timer = 0;
        _isTracking = true;
    }

    public override void StopTracking()
    {
        _isTracking = false;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeWinCondition : Condition
{
    [SerializeField] private float _maxTime;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TMP_Text _timeText;

    private float _timer;

    private void Update()
    {
        if (_isTracking == false)
        {
            return;
        }

        _timer += Time.deltaTime;
        UpdateUI();

        if (_timer >= _maxTime)
        {
            CompleteTarget();
        }
    }

    private void UpdateUI()
    {
        _progressBar.value = _timer;
        float timeLeft = _maxTime - _timer;
        _timeText.text = string.Format("{0}:{1}", ((int)timeLeft) / 60, ((int)timeLeft) % 60);
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

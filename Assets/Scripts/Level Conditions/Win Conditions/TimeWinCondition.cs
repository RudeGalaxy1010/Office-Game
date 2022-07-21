using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeWinCondition : Condition
{
    [SerializeField] private float _maxTime;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TMP_Text _timeText;

    private float _timer;

    private void OnEnable()
    {
        _progressBar.maxValue = _maxTime;
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        UpdateUI();

        if (_timer >= _maxTime)
        {
            Complete();
        }
    }

    private void UpdateUI()
    {
        _progressBar.value = _timer;
        float timeLeft = _maxTime - _timer;
        _timeText.text = string.Format("{0:d2}:{1:d2}", ((int)timeLeft) / 60, ((int)timeLeft) % 60);
    }
}

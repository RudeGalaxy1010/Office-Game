using UnityEngine;

public class FinalScreens : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _defeatScreen;
    [SerializeField] private LevelTarget _levelTarget;

    private void Awake()
    {
        _winScreen.SetActive(false);
        _defeatScreen.SetActive(false);
    }

    private void OnEnable()
    {
        _levelTarget.WinConditionsCompleted += OnWin;
        _levelTarget.DefeatConditionsCompleted += OnDefeat;
    }

    private void OnDisable()
    {
        _levelTarget.WinConditionsCompleted -= OnWin;
        _levelTarget.DefeatConditionsCompleted -= OnDefeat;
    }

    private void OnWin()
    {
        _winScreen.SetActive(true);
    }

    private void OnDefeat()
    {
        _defeatScreen.SetActive(true);
    }
}

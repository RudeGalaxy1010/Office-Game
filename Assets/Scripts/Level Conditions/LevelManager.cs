using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelTarget _levelTarget;

    private void OnEnable()
    {
        _levelTarget.WinConditionsCompleted += OnAllTargetsReached;
    }

    private void OnDisable()
    {
        _levelTarget.WinConditionsCompleted -= OnAllTargetsReached;
    }

    private void OnAllTargetsReached()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

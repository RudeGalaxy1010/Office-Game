using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private WorkPlaceManager _workPlaceManager;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private LevelTarget _levelTarget;

    private void OnEnable()
    {
        _levelTarget.WinConditionsCompleted += EnablePause;
        _levelTarget.DefeatConditionsCompleted += EnablePause;
    }

    private void OnDisable()
    {
        _levelTarget.WinConditionsCompleted -= EnablePause;
        _levelTarget.DefeatConditionsCompleted -= EnablePause;
    }

    public void EnablePause()
    {
        _workPlaceManager.Pause();
        _joystick.gameObject.SetActive(false);
    }

    public void DisablePause()
    {
        _workPlaceManager.Init();
        _joystick.gameObject.SetActive(true);
    }
}

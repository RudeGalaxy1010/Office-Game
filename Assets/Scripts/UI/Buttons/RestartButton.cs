using UnityEngine;

public class RestartButton : BaseButton
{
    [SerializeField] private Scenes _scenes;

    protected override void OnClick()
    {
        _scenes.LoadLevelScene();
    }
}

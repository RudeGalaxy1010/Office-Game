using UnityEngine;

public class ContinueButton : BaseButton
{
    [SerializeField] private Scenes _scenes;

    protected override void OnClick()
    {
        _scenes.LoadLevelScene();
    }
}

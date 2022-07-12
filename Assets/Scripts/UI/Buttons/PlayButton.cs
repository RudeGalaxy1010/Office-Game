using UnityEngine;

public class PlayButton : BaseButton
{
    [SerializeField] private Scenes _scenes;

    protected override void OnClick()
    {
        _scenes.LoadLevelScene();
    }
}

using UnityEngine;

public class MenuButton : BaseButton
{
    [SerializeField] private Scenes _scenes;

    protected override void OnClick()
    {
        _scenes.LoadMenuScene();
    }
}

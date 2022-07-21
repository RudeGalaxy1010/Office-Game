using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class BaseButton : MonoBehaviour
{
    protected Button Button;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    protected abstract void OnClick();
}

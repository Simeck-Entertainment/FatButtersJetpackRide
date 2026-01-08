using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonViewModel<T> : ViewModel<T> where T : Model
{
    [SerializeField] protected Button Button;

    protected override void Awake()
    {
        base.Awake();
        if (Button == null)
        {
            Button = GetComponent<Button>();
            if (Button == null)
            {
                Debug.LogError($"{name} unable to find a Button on this game object");
            }
        }

        Button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    protected override void OnModelChanged()
    {
        Button.interactable = IsEnabled();
    }

    protected virtual bool IsEnabled()
    {
        return true;
    }

    protected abstract void OnClick();
}

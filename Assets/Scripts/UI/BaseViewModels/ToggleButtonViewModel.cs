using UnityEngine;
using UnityEngine.UI;

public abstract class ToggleButtonViewModel<T> : ViewModel<T> where T : Model
{
    [SerializeField] protected Toggle ToggleButton;

    protected override void Awake()
    {
        base.Awake();
        if (ToggleButton == null)
        {
            ToggleButton = GetComponent<Toggle>();
            if (ToggleButton == null)
            {
                Debug.LogError($"{name} unable to find a Toggle on this game object");
            }
        }

        ToggleButton.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnDestroy()
    {
        ToggleButton.onValueChanged.RemoveListener(OnToggleChanged);
    }

    protected override void OnModelChanged()
    {
        ToggleButton.enabled = IsEnabled();
    }

    protected virtual bool IsEnabled()
    {
        return true;
    }

    protected abstract void OnToggleChanged(bool value);
}

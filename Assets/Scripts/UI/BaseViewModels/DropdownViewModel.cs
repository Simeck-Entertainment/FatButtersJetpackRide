using UnityEngine;
using TMPro;

public abstract class DropdownViewModel<T> :ViewModel<T> where T : Model
{
    [SerializeField] protected TMP_Dropdown Dropdown;

    protected override void Awake()
    {
        base.Awake();
        if (Dropdown == null)
        {
            Dropdown = GetComponent<TMP_Dropdown>();
            if (Dropdown == null)
            {
                Debug.LogError($"{name} unable to find a TMP_Dropdown on this game object");
            }
        }

        Dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    private void OnDestroy()
    {
        Dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
    }

    protected override void OnModelChanged()
    {
        Dropdown.enabled = IsEnabled();
    }

    protected virtual bool IsEnabled()
    {
        return true;
    }

    protected abstract void OnDropdownChanged(int index);
}
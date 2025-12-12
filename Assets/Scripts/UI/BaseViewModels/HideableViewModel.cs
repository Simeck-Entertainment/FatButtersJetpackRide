using UnityEngine;

public abstract class HideableViewModel<T> : ViewModel<T> where T : Model
{
    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }

    protected override void OnModelChanged()
    {
        gameObject.SetActive(IsVisible());
    }

    protected abstract bool IsVisible();
}

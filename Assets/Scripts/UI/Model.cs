using UnityEngine;
using UnityEngine.Events;

public abstract class Model : MonoBehaviour
{
    public UnityEvent OnModelChanged = new UnityEvent();

    protected void Refresh()
    {
        OnModelChanged.Invoke();
        RefreshInternal();
    }

    protected virtual void RefreshInternal()
    {
        // no-op
    }
}

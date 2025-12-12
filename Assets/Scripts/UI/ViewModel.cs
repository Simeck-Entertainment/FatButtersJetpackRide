using UnityEngine;

public abstract class ViewModel<T> : MonoBehaviour where T : Model
{
    [SerializeField] protected T Model;

    protected virtual void Awake()
    {
        if (Model == null)
        {
            Model = GetComponentInParent<T>(includeInactive: true);
            if (Model == null)
            {
                Debug.LogError($"{name} ({GetType().Name}) unable to find a model of type {typeof(T).Name}");
            }
        }

        Model.OnModelChanged.AddListener(OnModelChanged);
    }

    private void Start()
    {
        OnModelChanged(); // Run once on start to make sure everything is initialized correctly
    }

    private void OnDestroy()
    {
        Model.OnModelChanged.RemoveListener(OnModelChanged);
    }

    protected virtual void OnModelChanged()
    {
        // no-op
    }
}

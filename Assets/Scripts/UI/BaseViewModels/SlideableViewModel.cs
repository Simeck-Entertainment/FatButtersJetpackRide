using UnityEngine;

public abstract class SlideableViewModel<T> : ViewModel<T> where T : Model
{
    [SerializeField] private EditorLocalTransform disabledTransform = EditorLocalTransform.Identity;
    [SerializeField] private EditorLocalTransform enabledTransform = EditorLocalTransform.Identity;

    [SerializeField] protected float duration = 0.5f;

    [Tooltip("Changes whether this item starts enabled or disabled")]
    [SerializeField] protected bool isActive;

    private EditorLocalTransform startTransform;
    private EditorLocalTransform endTransform;
    private float timeSinceMoveStart = float.MaxValue;

    public void SetActive(bool active)
    {
        isActive = active;
        if (active)
        {
            startTransform = disabledTransform;
            endTransform = enabledTransform;
        }
        else
        {
            startTransform = enabledTransform;
            endTransform = disabledTransform;
        }
        timeSinceMoveStart = 0;
    }

    protected override void OnModelChanged()
    {
        var isNowActive = IsActive();
        if (isActive != isNowActive)
        {
            SetActive(isNowActive);
        }
    }

    protected abstract bool IsActive();

    private void Start()
    {
        if (isActive)
        {
            enabledTransform.UpdateTransform(transform);
        }
        else
        {
            disabledTransform.UpdateTransform(transform);
        }
    }

    private void FixedUpdate()
    {
        if (timeSinceMoveStart < duration)
        {
            timeSinceMoveStart += Time.deltaTime;
            if (timeSinceMoveStart > duration)
            {
                timeSinceMoveStart = duration;
            }

            var percentComplete = timeSinceMoveStart / duration;
            var nextTransform = GetNextTransform(startTransform, endTransform, percentComplete);
            nextTransform.UpdateTransform(transform);
        }
    }

    protected abstract EditorLocalTransform GetNextTransform(EditorLocalTransform startTransform, EditorLocalTransform endTransform, float percentComplete);
}

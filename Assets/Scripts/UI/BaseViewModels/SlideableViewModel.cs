using UnityEngine;

public abstract class SlideableViewModel<T> : ViewModel<T> where T : Model
{
    [SerializeField] private EditorLocalTransform disabledTransform = EditorLocalTransform.Identity;
    [SerializeField] private EditorLocalTransform enabledTransform = EditorLocalTransform.Identity;

    [SerializeField] private float duration = 0.5f;

    [Tooltip("Changes whether this item starts enabled or disabled")]
    [SerializeField] private bool isActive;

    private EditorLocalTransform targetTransform;
    private float timeSinceMoveStart = float.MaxValue;

    public void SetActive(bool active)
    {
        isActive = active;
        if (active)
        {
            targetTransform = enabledTransform;
        }
        else
        {
            targetTransform = disabledTransform;
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

    // TODO: This is pretty much done with the movement about halfway through the duration, why?
    // Might have to do the move manually
    private void FixedUpdate()
    {
        if (timeSinceMoveStart <= duration)
        {
            timeSinceMoveStart += Time.deltaTime;
            var percentComplete = timeSinceMoveStart / duration;

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetTransform.Position, percentComplete);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(targetTransform.Rotation), percentComplete);
            transform.localScale = Vector3.Lerp(transform.localScale, targetTransform.Scale, percentComplete);
        }
    }
}

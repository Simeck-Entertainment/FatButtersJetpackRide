using UnityEngine;

public abstract class LinearSlideableViewModel<T> : SlideableViewModel<T> where T : Model
{
    protected override EditorLocalTransform GetNextTransform(EditorLocalTransform startTransform, EditorLocalTransform endTransform, float percentComplete)
    {
        var nextTransform = new EditorLocalTransform
        {
            Position = Vector3.Lerp(startTransform.Position, endTransform.Position, percentComplete),
            Rotation = Vector3.Lerp(startTransform.Rotation, endTransform.Rotation, percentComplete),
            Scale = Vector3.Lerp(startTransform.Scale, endTransform.Scale, percentComplete)
        };  

        return nextTransform;
    }
}

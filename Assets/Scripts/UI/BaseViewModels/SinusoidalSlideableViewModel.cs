using UnityEngine;

public abstract class SinusoidalSlideableViewModel<T> : SlideableViewModel<T> where T : Model
{
    protected override EditorLocalTransform GetNextTransform(EditorLocalTransform startTransform, EditorLocalTransform endTransform, float percentComplete)
    {
        var nextTransform = new EditorLocalTransform
        {
            Position = CalculateVector(startTransform.Position, endTransform.Position, percentComplete),
            Rotation = CalculateVector(startTransform.Rotation, endTransform.Rotation, percentComplete),
            Scale = CalculateVector(startTransform.Scale, endTransform.Scale, percentComplete)
        };

        return nextTransform;
    }

    private Vector3 CalculateVector(Vector3 start, Vector3 end, float percentComplete)
    {
        var x = CalculateVectorComponent(start.x, end.x, percentComplete);
        var y = CalculateVectorComponent(start.y, end.y, percentComplete);
        var z = CalculateVectorComponent(start.z, end.z, percentComplete);

        return new Vector3(x, y, z);
    }

    private float CalculateVectorComponent(float start, float end, float percentComplete)
    {
        if (percentComplete == 1)
        {
            return end;
        }

        var amplitude = (end - start) / 2;
        var time = duration * percentComplete;
        var frequency = 1 / (duration * 2);

        return amplitude * Mathf.Cos(2 * Mathf.PI * frequency * time + Mathf.PI) + start + amplitude;
    }
}

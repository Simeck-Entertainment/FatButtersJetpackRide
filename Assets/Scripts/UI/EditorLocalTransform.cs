using System;
using UnityEngine;

[Serializable]
public struct EditorLocalTransform
{
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;

    public EditorLocalTransform(Transform transform)
    {
        Position = transform.localPosition;
        Rotation = transform.localRotation.eulerAngles;
        Scale = transform.localScale;
    }

    public void UpdateTransform(Transform transform)
    {
        transform.localPosition = Position;
        transform.localRotation = Quaternion.Euler(Rotation);
        transform.localScale = Scale;
    }

    public static EditorLocalTransform Identity
    {
        get
        {
            return new EditorLocalTransform
            {
                Position = Vector3.zero,
                Rotation = Vector3.zero,
                Scale = Vector3.one
            };
        }
    }

    public static EditorLocalTransform Zero
    {
        get
        {
            return new EditorLocalTransform
            {
                Position = Vector3.zero,
                Rotation = Vector3.zero,
                Scale = Vector3.zero
            };
        }
    }

    public static EditorLocalTransform operator +(EditorLocalTransform a, EditorLocalTransform b)
    {
        return new EditorLocalTransform
        {
            Position = a.Position + b.Position,
            Rotation = a.Rotation + b.Rotation,
            Scale = a.Scale + b.Scale
        };
    }

    public static EditorLocalTransform operator -(EditorLocalTransform a, EditorLocalTransform b)
    {
        return new EditorLocalTransform
        {
            Position = a.Position - b.Position,
            Rotation = a.Rotation - b.Rotation,
            Scale = a.Scale - b.Scale
        };
    }
}

public static class TransformExtensions
{
    public static void UpdateFromEditorLocalTransform(this Transform transform, EditorLocalTransform editorLocalTransform)
    {
        editorLocalTransform.UpdateTransform(transform);
    }
}

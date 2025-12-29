using System;
using UnityEngine;

[Serializable]
public struct EditorLocalTransform
{
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;

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
}

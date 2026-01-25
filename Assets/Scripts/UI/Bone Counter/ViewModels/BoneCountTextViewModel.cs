using UnityEngine;

public class BoneCountTextViewModel : TextViewModel<BoneCounterModel>
{
    protected override string GetText()
    {
        return Model.BoneCount.ToString();
    }
}

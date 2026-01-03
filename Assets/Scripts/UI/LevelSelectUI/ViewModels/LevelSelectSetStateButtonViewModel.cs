using UnityEngine;

public class LevelSelectSetStateButtonViewModel : ButtonViewModel<LevelSelectUIModel>
{
    [SerializeField] private LevelSelectUIState state;

    protected override void OnClick()
    {
        Model.UIState = state;
    }
}

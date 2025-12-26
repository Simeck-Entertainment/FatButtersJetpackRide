using UnityEngine;

public class ShowWhenLevelSelectStateActive : HideableViewModel<LevelSelectUIModel>
{
    [SerializeField] private LevelSelectUIState uiState;

    protected override bool IsVisible()
    {
        return Model.UIState == uiState;
    }
}
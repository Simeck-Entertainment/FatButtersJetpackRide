using UnityEngine;

public class MoveWhenLevelSelectStateActiveViewModel : SlideableViewModel<LevelSelectUIModel>
{
    [SerializeField] private LevelSelectUIState uiState;

    protected override bool IsActive()
    {
        return uiState == Model.UIState;
    }
}

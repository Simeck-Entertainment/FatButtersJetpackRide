using UnityEngine;

public class MoveWhenLevelSelectStateActiveViewModel : SinusoidalSlideableViewModel<LevelSelectUIModel>
{
    [SerializeField] private LevelSelectUIState uiState;

    protected override bool IsActive()
    {
        return uiState == Model.UIState;
    }
}

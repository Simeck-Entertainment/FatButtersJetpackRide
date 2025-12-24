public class LevelSelectResumeButtonViewModel : ButtonViewModel<LevelSelectUIModel>
{
    protected override void OnClick()
    {
        Model.UIState = LevelSelectUIState.Base;
    }
}
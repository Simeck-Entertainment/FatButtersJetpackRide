public class LevelSelectSettingsButtonViewModel : ButtonViewModel<LevelSelectUIModel>
{
    protected override void OnClick()
    {
        Model.UIState = LevelSelectUIState.Settings;
    }
}

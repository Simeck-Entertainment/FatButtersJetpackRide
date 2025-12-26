public class ToLevelSelectButtonViewModel : ButtonViewModel<SettingsMenuModel>
{
    protected override void OnClick()
    {
        Model.ToLevelSelect();
    }
}

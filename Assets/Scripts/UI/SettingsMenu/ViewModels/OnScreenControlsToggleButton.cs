public class OnScreenControlsToggleButton : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnToggleChanged(bool value)
    {
        Model.ToggleOnScreenControls(value);
    }
}
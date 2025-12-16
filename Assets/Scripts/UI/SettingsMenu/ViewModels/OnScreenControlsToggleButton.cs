public class OnScreenControlsToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.CollectibleData.OnScreenControlsEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.ToggleOnScreenControls(value);
    }
}

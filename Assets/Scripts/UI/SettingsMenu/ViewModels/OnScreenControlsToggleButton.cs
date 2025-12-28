public class OnScreenControlsToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.OnScreenControlsEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.OnScreenControlsEnabled = value;
    }
}

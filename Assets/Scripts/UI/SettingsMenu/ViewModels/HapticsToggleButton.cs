public class HapticsToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.HapticsEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.HapticsEnabled = value;
    }
}

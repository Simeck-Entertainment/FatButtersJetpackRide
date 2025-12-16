public class HapticsToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.CollectibleData.HapticsEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.ToggleHaptics(value);
    }
}

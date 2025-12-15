public class HapticsToggleButton : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnToggleChanged(bool value)
    {
        Model.ToggleHaptics(value);
    }
}

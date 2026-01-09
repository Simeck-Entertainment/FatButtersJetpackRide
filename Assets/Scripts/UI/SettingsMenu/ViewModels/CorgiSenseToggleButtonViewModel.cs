public class CorgiSenseToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.CorgiSenseEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.CorgiSenseEnabled = value;
    }
}

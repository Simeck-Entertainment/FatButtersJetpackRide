public class PauseMenuAdsToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.PauseMenuAdsEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.PauseMenuAdsEnabled = value;
    }
}

public class LevelSelectAdsToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.LevelSelectAdsEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.LevelSelectAdsEnabled = value;
    }
}

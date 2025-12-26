public class PostLevelAdsToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.PostLevelAdsEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.PostLevelAdsEnabled = value;
    }
}

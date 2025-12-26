public class BoneDoublerVideoAdsToggleButtonViewModel : ToggleButtonViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        ToggleButton.isOn = Model.BoneDoublerVideoAdsEnabled;
    }

    protected override void OnToggleChanged(bool value)
    {
        Model.BoneDoublerVideoAdsEnabled = value;
    }
}

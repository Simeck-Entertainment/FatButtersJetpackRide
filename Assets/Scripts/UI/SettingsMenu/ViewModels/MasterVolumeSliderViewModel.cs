public class MasterVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        Slider.value = Model.CollectibleData.MasterVolumeLevel / Model.VolumeMultiplier;
    }

    protected override void OnSliderChanged(float value)
    {
        Model.SetMasterVolume(value);
    }
}

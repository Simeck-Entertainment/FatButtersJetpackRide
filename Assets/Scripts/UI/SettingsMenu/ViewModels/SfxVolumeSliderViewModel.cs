public class SfxVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        Slider.value = Model.CollectibleData.SFXVolumeLevel / Model.VolumeMultiplier;
    }

    protected override void OnSliderChanged(float value)
    {
        Model.SetSfxVolume(value);
    }
}

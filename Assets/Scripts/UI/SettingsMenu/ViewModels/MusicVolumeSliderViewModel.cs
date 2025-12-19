public class MusicVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        Slider.value = Model.CollectibleData.MusicVolumeLevel / Model.VolumeMultiplier;
    }

    protected override void OnSliderChanged(float value)
    {
        Model.SetMusicVolume(value);
    }
}

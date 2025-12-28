public class MusicVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        Slider.value = Model.MusicVolume;
    }

    protected override void OnSliderChanged(float value)
    {
        Model.MusicVolume = value;
    }
}

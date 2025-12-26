public class SfxVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        Slider.value = Model.SfxVolume;
    }

    protected override void OnSliderChanged(float value)
    {
        Model.SfxVolume = value;
    }
}

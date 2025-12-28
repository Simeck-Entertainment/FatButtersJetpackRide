public class MasterVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        Slider.value = Model.MasterVolume;
    }

    protected override void OnSliderChanged(float value)
    {
        Model.MasterVolume = value;
    }
}

public class SfxVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnSliderChanged(float value)
    {
        Model.SetSfxVolume(value);
    }
}

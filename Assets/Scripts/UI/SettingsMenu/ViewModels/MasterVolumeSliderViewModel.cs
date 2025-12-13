public class MasterVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnSliderChanged(float value)
    {
        Model.SetMasterVolume(value);
    }
}

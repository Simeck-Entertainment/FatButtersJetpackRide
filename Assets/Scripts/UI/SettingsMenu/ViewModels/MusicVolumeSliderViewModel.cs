using UnityEngine;

public class MusicVolumeSliderViewModel : SliderViewModel<SettingsMenuModel>
{
    protected override void OnSliderChanged(float value)
    {
        Model.SetMusicVolume(value);
    }
}

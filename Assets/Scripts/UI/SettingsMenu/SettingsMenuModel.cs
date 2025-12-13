using UnityEngine;

public class SettingsMenuModel : Model
{

    [SerializeField] private CollectibleData CollectibleData;
    [SerializeField] private float VolumeMultiplier = 0.9f;

    public void SetMasterVolume(float value)
    {
        CollectibleData.MasterVolumeLevel = value * VolumeMultiplier;
    }

    public void SetMusicVolume(float value)
    {
        CollectibleData.MusicVolumeLevel = value * VolumeMultiplier;
    }

    public void SetSfxVolume(float value)
    {
        CollectibleData.SFXVolumeLevel = value * VolumeMultiplier;
    }
}

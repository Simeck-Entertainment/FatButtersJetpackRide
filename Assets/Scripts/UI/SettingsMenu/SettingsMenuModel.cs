using UnityEngine;

public class SettingsMenuModel : Model
{
    [SerializeField] public CollectibleData CollectibleData;
    [SerializeField] public float VolumeMultiplier = 0.9f;
    [SerializeField] private GameObject OnScreenControlObj;
    [SerializeField] private UIManager uiManager;

    private SaveManager saveManager;

    private void Start()
    {
        saveManager = Helper.NabSaveData().GetComponent<SaveManager>();
        saveManager.Load();
    }

    public void SetMasterVolume(float value)
    {
        CollectibleData.MasterVolumeLevel = value * VolumeMultiplier;
        Save();
    }

    public void SetMusicVolume(float value)
    {
        CollectibleData.MusicVolumeLevel = value * VolumeMultiplier;
        Save();
    }

    public void SetSfxVolume(float value)
    {
        CollectibleData.SFXVolumeLevel = value * VolumeMultiplier;
        Save();
    }

    public void ToggleHaptics(bool value)
    {
        CollectibleData.HapticsEnabled = value;
        Save();
    }

    public void ToggleOnScreenControls(bool value)
    {
        CollectibleData.OnScreenControlsEnabled = value;

        if (OnScreenControlObj != null)
        {
            // TODO Drake: control this with a hideable controller, requires a higher level UI model on our "UIObject"
            // This behavior does not belong in the settings model
            OnScreenControlObj.SetActive(value);
        }

       Save();
    }

    public void ResumeGame()
    {
        // TODO Drake: this feels like an antipattern.
        // Maybe the resume button should be a part of the higher level UI model and live outside the settings menu prefab
        uiManager.DeActivatePauseMenu();
    }

    private void Save()
    {
        saveManager.Save();
        Refresh();
    }
}

using System;
using UnityEngine;

public class SettingsMenuModel : Model
{
    // TODO Drake: make properties on this model for the fields used in the view models rather than letting them access collectible data

    [SerializeField] public float VolumeMultiplier = 0.9f;
    [SerializeField] private GameObject OnScreenControlObj;
    [SerializeField] private CollectibleData collectibleData; // TODO: Consider eliminating this and making it work on the saveManager.collectibleData
    [SerializeField] private UIManager uiManager;

    private SaveManager saveManager;

    #region properties

    private SettingsPage _currentPage = SettingsPage.Base;
    public SettingsPage CurrentPage
    {
        get
        {
            return _currentPage;
        }
        set
        {
            _currentPage = value;
            Refresh();
        }
    }

    public float MasterVolume
    {
        get
        {
            return collectibleData.MasterVolumeLevel / VolumeMultiplier;
        }
        set
        {
            collectibleData.MasterVolumeLevel = value * VolumeMultiplier;
            Save();
        }
    }

    public float MusicVolume
    {
        get
        {
            return collectibleData.MusicVolumeLevel / VolumeMultiplier;
        }
        set
        {
            collectibleData.MusicVolumeLevel = value * VolumeMultiplier;
            Save();
        }
    }

    public float SfxVolume
    {
        get
        {
            return collectibleData.SFXVolumeLevel / VolumeMultiplier;
        }
        set
        {
            collectibleData.SFXVolumeLevel = value * VolumeMultiplier;
            Save();
        }
    }

    public int GraphicsQuality
    {
        get
        {
            return collectibleData.GraphicsQualityLevel;
        }
        set
        {

            QualitySettings.SetQualityLevel(value);
            collectibleData.GraphicsQualityLevel = value;
            Save();
        }
    }

    public bool HapticsEnabled
    {
        get
        {
            return collectibleData.HapticsEnabled;
        }
        set
        {
            collectibleData.HapticsEnabled = value;
            Save();
        }
    }

    public bool OnScreenControlsEnabled
    {
        get
        {
            return collectibleData.OnScreenControlsEnabled;
        }
        set
        {
            collectibleData.OnScreenControlsEnabled = value;

            if (OnScreenControlObj != null)
            {
                // TODO Drake: control this with a hideable controller, requires a higher level UI model on our "UIObject"
                // This behavior does not belong in the settings model
                OnScreenControlObj.SetActive(value);
            }

            Save();
        }
    }

    public bool LevelSelectAdsEnabled
    {
        get
        {
            return saveManager.userInfo.LevelSelectBanners;
        }
        set
        {
            saveManager.userInfo.LevelSelectBanners = value;
            Save();
        }
    }

    public bool PauseMenuAdsEnabled
    {
        get
        {
            return saveManager.userInfo.PauseMenuBanners;
        }
        set
        {
            saveManager.userInfo.PauseMenuBanners = value;
            Save();
        }
    }

    public bool PostLevelAdsEnabled
    {
        get
        {
            return saveManager.userInfo.InterstitialToggle;
        }
        set
        {
            saveManager.userInfo.InterstitialToggle = value;
            Save();
        }
    }

    public bool BoneDoublerVideoAdsEnabled
    {
        get
        {
            return saveManager.userInfo.BoneDoublerToggle;
        }
        set
        {
            saveManager.userInfo.BoneDoublerToggle = value;
            Save();
        }
    }

    #endregion

    private void Start()
    {
        saveManager = Helper.NabSaveData().GetComponent<SaveManager>();
        saveManager.Load();
    }

    public void ShowPrivacyPolicy()
    {
        Application.OpenURL("https://fatbutters.simeck.com/privacyPolicy.txt");
    }

    public void ToLevelSelect()
    {
        collectibleData.HASBALL = false;
        saveManager.Save();

        // EnableGameplayIndicators(); // TODO: Make a separate model and hideable view model for this
        Time.timeScale = 1.0f; // TODO: the pause, unpause function should be handled globally, not in a controller

        Helper.LoadToLevel(Levels.LevelSelect);
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

public enum SettingsPage
{
    Base,
    Ads
}

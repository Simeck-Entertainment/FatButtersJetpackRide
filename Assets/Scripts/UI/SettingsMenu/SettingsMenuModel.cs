using System;
using UnityEngine;

public class SettingsMenuModel : Model
{
    [SerializeField] public float VolumeMultiplier = 0.9f;

    private SaveManager saveManager;

    private CollectibleData collectibleData => saveManager.collectibleData;

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

            Save();
        }
    }

    public bool CorgiSenseEnabled
    {
        get
        {
            return collectibleData.CorgiSenseEnabled;
        }
        set
        {
            collectibleData.CorgiSenseEnabled = value;
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

    private void Awake()
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

        Time.timeScale = 1.0f; // TODO Drake: Consider a global utility for pause/resume

        Levels.Load(Levels.LevelSelect);
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

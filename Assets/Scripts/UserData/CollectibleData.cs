using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="newCollectibleData", menuName ="Data/Collectible Data")] //
public class CollectibleData : ScriptableObject
{
    [SerializeField] private int bones; 
    [Header("Store purchases")]
    public int fuelUpgradeLevel;
    public int thrustUpgradeLevel;
    public int treatsUpgradeLevel;
    public bool HASBALL; //ball is 10 seconds of non-explodey time.
    public bool killAds;
    public bool[] LevelBeaten;
    public int CurrentSkin;
    public bool[] HaveSkins;
    public float MasterVolumeLevel;
    public float MusicVolumeLevel;
    public float SFXVolumeLevel;
    public bool HapticsEnabled;
    public bool OnScreenControlsEnabled;
    public bool CorgiSenseEnabled;
    public int GraphicsQualityLevel;

    [Header("In-level collectible Counters")]
    public int Keys;
    
    [Header("Dev Options")]
    public bool GameplayTestingMode;
    public bool ignoreSaveData;

    public int BONES
    {
        get
        {
            return bones;
        }
        set
        {
            bones = value;
            OnBonesChanged.Invoke();
        }
    }

    public UnityEvent OnBonesChanged { get; set; } = new UnityEvent();
}
